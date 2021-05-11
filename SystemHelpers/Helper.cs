using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SystemHelpers
{
    public static class Helper
    {
        private static readonly ConcurrentDictionary<(Type Type, string PropertyName), Func<object, object>> Getters = new();
        public static object GetPropertyValue(object instance, string name)
        {
            var key = (instance.GetType(), name);
            static Func<object, object> GetProperty((Type Type, string PropertyName) key)
            {
                var o = Expression.Parameter(typeof(object));
                var i = Expression.Convert(o, key.Type);
                var property = Expression.Property(i, key.PropertyName);
                var result = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<object, object>>(result, o);
                return lambda.Compile();
            }
            var getter = Getters.GetOrAdd(key, GetProperty);
            return getter(instance);
        }
        private static readonly ConcurrentDictionary<(Type Type, string PropertyName, Type ValueType), Delegate> Setters = new();
        public static void SetPropertyValue<TInstance, TProperty>(TInstance instance, string name, TProperty value)
        {
            var key = (instance.GetType(), name, typeof(TProperty));
            static Action<TInstance, TProperty> SetProperty((Type Type, string PropertyName, Type ValueType) key)
            {
                var valueParameter = Expression.Parameter(typeof(TProperty));
                var instanceParameter = Expression.Parameter(typeof(TInstance));
                var i = Expression.Convert(instanceParameter, key.Type);
                var property = Expression.Property(i, key.PropertyName);
                var v = Expression.Convert(valueParameter, property.Type);
                var result = Expression.Assign(property, v);
                var lambda = Expression.Lambda<Action<TInstance, TProperty>>(result, instanceParameter, valueParameter);
                return lambda.Compile();
            }
            var setter = (Action<TInstance, TProperty>)Setters.GetOrAdd(key, SetProperty);
            setter(instance, value);
        }


        public static IEnumerable<TDst> Map<TSrc, TDst>(this IEnumerable<TSrc> src) where TDst : new() => src.Select(i => i.Map<TSrc, TDst>());
        public static TDst Map<TSrc, TDst>(this TSrc src) where TDst : new() => ((Func<TSrc, TDst, TDst>)MapDelegates.GetOrAdd((typeof(TSrc), typeof(TDst)), t => CreateCopyMethod<TSrc, TDst>()))(src, ActivateInstance<TDst>());
        private static readonly ConcurrentDictionary<Type, Delegate> ActivateDelegates = new();
        public static object ActivateInstance(Type type)
        {
            static Delegate Activate(Type type)
            {
                var ctor = Expression.New(type);
                var lambda = Expression.Lambda(ctor);
                return lambda.Compile();
            }
            var activator = ActivateDelegates.GetOrAdd(type, Activate);
            return activator.DynamicInvoke();
        }
        public static T ActivateInstance<T>() where T : new()
        {
            static Delegate Activate(Type type)
            {
                var ctor = Expression.New(type);
                var lambda = Expression.Lambda(ctor);
                return lambda.Compile();
            }
            var activator = (Func<T>)ActivateDelegates.GetOrAdd(typeof(T), Activate);
            return activator();
        }
        private static readonly ConcurrentDictionary<(Type Source, Type Destenation), Delegate> MapDelegates = new ConcurrentDictionary<(Type, Type), Delegate>();
        private static readonly Lazy<CaseIgnoreComparer> _comparer = new(() => new CaseIgnoreComparer());
        public static IEqualityComparer<string> CaseIgnoreComparer => _comparer.Value;

        public static TDst Map<TSrc, TDst>(TSrc src, TDst dst) => ((Func<TSrc, TDst, TDst>)MapDelegates.GetOrAdd((typeof(TSrc), typeof(TDst)), t => CreateCopyMethod<TSrc, TDst>()))(src, dst);
        private static Func<TSrc, TDst, TDst> CreateCopyMethod<TSrc, TDst>()
        {
            var typeSrc = typeof(TSrc);
            var typeDst = typeof(TDst);
            var srcExpression = Expression.Parameter(typeSrc);
            var dstExpression = Expression.Parameter(typeDst);
            var block = new List<Expression>();
            var propsSrc = typeSrc.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite).Select(p => p.Name);
            var propsDst = typeDst.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite).Select(p => p.Name);
            var propNames = propsSrc.Intersect(propsDst);
            foreach (string prop in propNames)
            {
                block.Add(Expression.Assign(Expression.Property(dstExpression, prop), Expression.Property(srcExpression, prop)));
            }
            block.Add(dstExpression);
            var body = Expression.Block(block);
            return Expression.Lambda<Func<TSrc, TDst, TDst>>(body, srcExpression, dstExpression).Compile();
        }

        private static Delegate CreateCopyMethod<TDst>(Type[] srcTypes)
        {
            var typeDst = typeof(TDst);
            var srcExpressions = srcTypes.ToDictionary(t => t, t => Expression.Parameter(t));
            var dstExpression = Expression.Parameter(typeDst);
            var block = new List<Expression>();
            var propsSrc = new Dictionary<string, Type>();
            var propsDst = typeDst.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite).Select(p => p.Name).ToHashSet();

            foreach (var (name, type) in from t in srcTypes
                                         from p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                         where p.CanRead && p.CanWrite && !propsSrc.ContainsKey(p.Name) && propsDst.Contains(p.Name)
                                         select (p.Name, Type: t))
                propsSrc.Add(name, type);

            foreach (var prop in propsSrc)
                block.Add(Expression.Assign(Expression.Property(dstExpression, prop.Key), Expression.Property(srcExpressions[prop.Value], prop.Key)));
            block.Add(dstExpression);
            var body = Expression.Block(block);
            return Expression.Lambda(body, srcExpressions.Values.AsEnumerable().Append(dstExpression)).Compile();
        }
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            foreach (var item in src)
                action(item);
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src) => new HashSet<T>(src);
        public static IEnumerable<T> Append<T>(this IEnumerable<T> src, T element)
        {
            foreach (var item in src)
                yield return item;
            yield return element;
        }

        public static string GetPropertyDisplayName(this PropertyInfo p) => p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? p.Name;

        public static object FixType(this object value, Type type)
        {
            if ((type == typeof(DateTime?) || type == typeof(DateTime)) && value is double v) return DateTime.FromOADate(v);
            return value;
        }
    }
}
