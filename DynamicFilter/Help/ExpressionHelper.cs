using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicFilter.Help
{
    public static class ExpressionHelper
    {
        internal static Expression<Action<object, T>> CreateSetProperty<T>(object defaultObject, string propertyName)
        {
            var varriable = Expression.Variable(typeof(object));
            var varriableConverted = Expression.Convert(varriable, defaultObject.GetType());
            var value = Expression.Variable(typeof(T));
            var property = Expression.PropertyOrField(varriableConverted, propertyName);
            var act = Expression.Assign(property, value);
            return Expression.Lambda<Action<object, T>>(act, varriable, value);
        }
        internal static Expression<Func<object, T>> CreateGetProperty<T>(object defaultObject, string propertyName)
        {
            var varriable = Expression.Variable(typeof(object));
            var varriableConverted = Expression.Convert(varriable, defaultObject.GetType());
            Expression property = Expression.PropertyOrField(varriableConverted, propertyName);
            if (property.Type != typeof(T)) property = Expression.Convert(property, typeof(T));
            return Expression.Lambda<Func<object, T>>(property, varriable);
        }

        internal static Expression CheckNull(this Expression condition, Expression property)
        {
            return property.Type.CanBeNull() ? property.IsNotNull().And(condition) : condition;
        }
        internal static Expression IsNotNull(this Expression property)
        {
            return Expression.NotEqual(property, Expression.Constant(null, property.Type));
        }

        internal static Expression Equal(this Expression left, Expression right)
        {
            var type = left.Type;
            if (!type.IsClass) return Expression.Equal(left, right);
            if (type.GetInterface(typeof(IEquatable<>).MakeGenericType(type).Name) is not null)
                return left.IsNotNull().And(Expression.Call(left, type.GetMethod(nameof(IEquatable<int>.Equals), BindingFlags.Instance | BindingFlags.Public, new[] { type }), right));
            return left.IsNotNull().And(Expression.Call(left, type.GetMethod(nameof(object.Equals), BindingFlags.Instance | BindingFlags.Public, new[] { typeof(object) }), right));
        }

        internal static Expression And(this Expression leftBoolean, Expression rightBoolean)
        {
            return Expression.AndAlso(leftBoolean, rightBoolean);
        }
        internal static Expression ConvertTo(this Expression expression, Type type) => Expression.Convert(expression, type);
        internal static bool CanBeNull(this Type type) => type.IsClass || type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        internal static Type GetNullubleType(this object value) => value.GetType() is var type && type.CanBeNull() ? type : typeof(Nullable<>).MakeGenericType(type);
    }
}
