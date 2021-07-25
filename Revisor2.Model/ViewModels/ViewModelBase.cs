using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Revisor2.Model.ViewModels
{
    public abstract class ViewModelBase<T, TKey> : INotifyPropertyChanged, IHasId<TKey>, IEquatable<T>
        where T : ViewModelBase<T, TKey> 
    {
        public ViewModelBase(TKey id)
        {
            Id = id;
        }
        public abstract string DisplayMember { get; }
        public TKey Id { get; set; }
        public override string ToString() => DisplayMember;
        protected void Set<TProperty>(ref TProperty oldValue, TProperty newValue, [CallerMemberName] string propertyName = "")
        {
            if (oldValue.Equals(newValue)) return;
            OnPropertyChange(propertyName);
        }
        protected void OnPropertyChange([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj) => Equals(obj as T);
        public bool Equals(T other) => other is not null && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        public override int GetHashCode() => HashCode.Combine(Id);
        public static bool operator ==(ViewModelBase<T, TKey> left, ViewModelBase<T, TKey> right) => left is T && right is T && EqualityComparer<ViewModelBase<T, TKey>>.Default.Equals(left, right);
        public static bool operator !=(ViewModelBase<T, TKey> left, ViewModelBase<T, TKey> right) => !(left == right);
    }
    public interface IHasId<TKey>
    {
        public TKey Id { get; }
    }
}
