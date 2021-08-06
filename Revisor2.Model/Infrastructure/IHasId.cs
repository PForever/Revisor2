namespace Revisor2.Model.Infrastructure
{
    //public abstract class DomainModelBase<T, TKey> : INotifyPropertyChanged, IHasId<TKey>, IEquatable<T>
    //    where T : DomainModelBase<T, TKey>
    //{
    //    private TKey id;

    //    public DomainModelBase()
    //    {
    //        Id = default;
    //        IsNew = true;
    //    }
    //    public DomainModelBase(TKey id)
    //    {
    //        Id = id;
    //    }
    //    public bool IsNew { get; private set; }
    //    public abstract string DisplayMember { get; }
    //    public TKey Id
    //    {
    //        get => id; set
    //        {
    //            Set(ref id, value);
    //            IsNew = false;
    //        }
    //    }
    //    public override string ToString() => DisplayMember;
    //    protected void Set<TProperty>(ref TProperty oldValue, TProperty newValue, [CallerMemberName] string propertyName = "")
    //    {
    //        if (oldValue.Equals(newValue)) return;
    //        OnPropertyChange(propertyName);
    //    }
    //    protected void OnPropertyChange([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public override bool Equals(object obj) => Equals(obj as T);
    //    public bool Equals(T other) => other is not null && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    //    public override int GetHashCode() => HashCode.Combine(Id);
    //    public static bool operator ==(DomainModelBase<T, TKey> left, DomainModelBase<T, TKey> right) => left is T && right is T && EqualityComparer<DomainModelBase<T, TKey>>.Default.Equals(left, right);
    //    public static bool operator !=(DomainModelBase<T, TKey> left, DomainModelBase<T, TKey> right) => !(left == right);
    //}
    public interface IHasId<TKey>
    {
        bool IsNew { get; }
        public TKey Id { get; }
    }
}
