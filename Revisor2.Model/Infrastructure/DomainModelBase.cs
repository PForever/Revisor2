using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.Infrastructure
{

    public abstract class DomainModelBase<T, TKey> : INotifyPropertyChanged, IViewModelBase, IHasId<TKey>, IEquatable<T>
        where T : DomainModelBase<T, TKey>
    {
        public T This => (T) this;
        public DomainModelBase()
        {
            Id = default;
            IsNew = true;
        }
        public DomainModelBase(TKey id)
        {
            Id = id;
        }

        public bool IsNew { get; private set; }
        private TKey _id;
        public TKey Id
        {
            get => _id; set
            {
                Set(ref _id, value);
                if (IsNew && IsChanged) IsNew = false;
            }
        }

        private ConcurrentDictionary<string, Delegate> _changestComparer = new ConcurrentDictionary<string, Delegate>();
        private ConcurrentDictionary<string, NotifyCollectionChangedEventHandler> _collectionChangedHandler = new ConcurrentDictionary<string, NotifyCollectionChangedEventHandler>();
        private ConcurrentDictionary<string, bool> _changestStates = new ConcurrentDictionary<string, bool>();
        private ConcurrentDictionary<string, Func<bool>> _viewModelChangestStates = new ConcurrentDictionary<string, Func<bool>>();
        protected virtual ILookup<string, string> Dependencies { get; }
        public bool IsChanged => _changestStates.Values.Any(v => v) || _viewModelChangestStates.Values.Any(v => v());
        protected virtual void SetVm<TProperty>(ref TProperty oldValue, TProperty newValue, [CallerMemberName] string propertyName = "") where TProperty : IViewModelBase
        {
            if (oldValue is IEquatable<TProperty> v && v.Equals(newValue) || (oldValue?.Equals(newValue) ?? newValue is null)) return;
            Func<bool> check = () => newValue.IsChanged;
            _viewModelChangestStates.AddOrUpdate(propertyName, k => check, (k, old) => check);
            SetInternal(ref oldValue, newValue, propertyName);
        }
        protected virtual void Set<TProperty>(ref TProperty oldValue, TProperty newValue, [CallerMemberName] string propertyName = "")
            => Set(ref oldValue, newValue, (o, n) => o?.Equals(n) is true, propertyName);

        protected virtual void Set<TProperty>(ref TProperty oldValue, TProperty newValue, Func<TProperty, TProperty, bool> comparer, [CallerMemberName] string propertyName = "")
        {
            if (comparer(oldValue, newValue)) return;
            var old = oldValue;
            bool CheckIsOld(TProperty value)
            {
                var isOld = (Func<TProperty, bool>)_changestComparer[propertyName];
                return isOld(value);
            }
            if (_changestComparer.ContainsKey(propertyName))
            {
                var newState = !CheckIsOld(newValue);
                _ = _changestStates.TryGetValue(propertyName, out bool oldState);
                _ = _changestStates.TryUpdate(propertyName, newState, oldState);
            }
            else
            {
                Func<TProperty, bool> isOld = n => comparer(n, old);
                //либо капарера ещё нету и тогда состояние точно было изменено, либо кампарер добавили параллельным потоком и нам нужно сходить и проверить, было ли изменено состояние
                //TODO потокобезопасное присовение
                _ = _changestStates.TryAdd(propertyName, _changestComparer.TryAdd(propertyName, isOld) || !CheckIsOld(newValue));
            }
            SetInternal(ref oldValue, newValue, propertyName);
        }

        private void SetInternal<TProperty>(ref TProperty oldValue, TProperty newValue, [CallerMemberName] string propertyName = "")
        {
            oldValue = newValue;
            OnPropertyChanged(propertyName);
        }
        protected void OnPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
            if (Dependencies is ILookup<string, string> dependencies && dependencies.Contains(memberName)) foreach (var n in dependencies[memberName]) OnPropertyChanged(n);
        }

        public override bool Equals(object obj) => Equals(obj as T);
        public bool Equals(T other) => other is not null && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        public override int GetHashCode() => HashCode.Combine(Id);
        public static bool operator ==(DomainModelBase<T, TKey> left, DomainModelBase<T, TKey> right) => left is T && right is T && EqualityComparer<DomainModelBase<T, TKey>>.Default.Equals(left, right);
        public static bool operator !=(DomainModelBase<T, TKey> left, DomainModelBase<T, TKey> right) => !(left == right);

        public abstract string DisplayMember { get; }
        public override string ToString() => DisplayMember;
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
