using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using SystemHelpers;

namespace Revisor2.Model.Infrastructure
{
    public interface IHasParent<TParent>
    {
        TParent Parent { get; set; }
    }
    public class DomainModelCollection<T, TParent> : IHasParent<TParent>, IViewModelBase, INotifyCollectionChanged, IList<T>, IList
        where T : class, IViewModelBase
    {
        private Action<T, TParent> _parentSetter;
        public TParent Parent { get; set; }

        public DomainModelCollection(IEnumerable<T> src)
        {
            Collection = new ObservableCollection<T>(src);
            Collection.CollectionChanged += OnCollectionChanged;
            _parentSetter = (_,_) => { };
        }

        public DomainModelCollection(IEnumerable<T> src, TParent parent, Action<T, TParent> parentSetter)
        {
            Parent = parent;
            Collection = new ObservableCollection<T>(src.ForEachTransform(p => parentSetter(p, parent)));
            Collection.CollectionChanged += OnCollectionChanged;
            _parentSetter = parentSetter;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            void Change(ref HashSet<T> minus, ref HashSet<T> plus, List<T> delta)
            {
                if (plus == null) plus = new HashSet<T>();
                if (minus != null)
                {
                    foreach (var item in delta)
                    {
                        if (minus.Contains(item)) minus.Remove(item);
                        else plus.Add(item);
                    }
                }
                else
                {
                    foreach (var item in delta) plus.Add(item);
                }
            }
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Change(ref _removed, ref _added, e.NewItems.Cast<T>().ToList());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Change(ref _added, ref _removed, e.OldItems.Cast<T>().ToList());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    return;
                case NotifyCollectionChangedAction.Move:
                    return;
                case NotifyCollectionChangedAction.Reset:
                    return;
                default:
                    return;
            }
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)Collection).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _parentSetter(item, Parent);
            ((IList<T>)Collection).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)Collection).RemoveAt(index);
        }

        public void Add(T item)
        {
            _parentSetter(item, Parent);
            ((ICollection<T>)Collection).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)Collection).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)Collection).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Collection).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)Collection).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Collection).GetEnumerator();
        }

        public int Add(object value)
        {
            return ((IList)Collection).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList)Collection).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IList)Collection).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList)Collection).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)Collection).Remove(value);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)Collection).CopyTo(array, index);
        }

        private HashSet<T> _added;
        private HashSet<T> _removed;

        public ObservableCollection<T> Collection { get; }
        public int AddedCount => _added?.Count ?? 0;
        public IEnumerable<T> Added => _added;
        public int RemovedCount => _removed?.Count ?? 0;
        public IEnumerable<T> Removed => _removed;
        public bool IsChanged => _added.Count != 0 || _removed.Count != 0 || Collection.Any(r => r.IsChanged);

        public int Count => ((ICollection<T>)Collection).Count;

        public bool IsReadOnly => ((ICollection<T>)Collection).IsReadOnly;

        public bool IsFixedSize => ((IList)Collection).IsFixedSize;

        public object SyncRoot => ((ICollection)Collection).SyncRoot;

        public bool IsSynchronized => ((ICollection)Collection).IsSynchronized;

        object IList.this[int index] { get => ((IList)Collection)[index]; set => ((IList)Collection)[index] = value; }
        public T this[int index] { get => ((IList<T>)Collection)[index]; set => ((IList<T>)Collection)[index] = value; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }



    public class DomainModelCollection<T> : IViewModelBase, INotifyCollectionChanged, IList<T>, IList
        where T : class, IViewModelBase
    {
        public DomainModelCollection(IEnumerable<T> src)
        {
            Collection = new ObservableCollection<T>(src);
            Collection.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            void Change(ref HashSet<T> minus, ref HashSet<T> plus, List<T> delta)
            {
                if (plus == null) plus = new HashSet<T>();
                if (minus != null)
                {
                    foreach (var item in delta)
                    {
                        if (minus.Contains(item)) minus.Remove(item);
                        else plus.Add(item);
                    }
                }
                else
                {
                    foreach (var item in delta) plus.Add(item);
                }
            }
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Change(ref _removed, ref _added, e.NewItems.Cast<T>().ToList());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Change(ref _added, ref _removed, e.OldItems.Cast<T>().ToList());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    return;
                case NotifyCollectionChangedAction.Move:
                    return;
                case NotifyCollectionChangedAction.Reset:
                    return;
                default:
                    return;
            }
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)Collection).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)Collection).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)Collection).RemoveAt(index);
        }

        public void Add(T item)
        {
            ((ICollection<T>)Collection).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)Collection).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)Collection).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Collection).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)Collection).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Collection).GetEnumerator();
        }

        public int Add(object value)
        {
            return ((IList)Collection).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList)Collection).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IList)Collection).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList)Collection).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)Collection).Remove(value);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)Collection).CopyTo(array, index);
        }

        private HashSet<T> _added;
        private HashSet<T> _removed;

        public ObservableCollection<T> Collection { get; }
        public int AddedCount => _added?.Count ?? 0;
        public IEnumerable<T> Added => _added;
        public int RemovedCount => _removed?.Count ?? 0;
        public IEnumerable<T> Removed => _removed;
        public bool IsChanged => _added.Count != 0 || _removed.Count != 0 || Collection.Any(r => r.IsChanged);

        public int Count => ((ICollection<T>)Collection).Count;

        public bool IsReadOnly => ((ICollection<T>)Collection).IsReadOnly;

        public bool IsFixedSize => ((IList)Collection).IsFixedSize;

        public object SyncRoot => ((ICollection)Collection).SyncRoot;

        public bool IsSynchronized => ((ICollection)Collection).IsSynchronized;

        object IList.this[int index] { get => ((IList)Collection)[index]; set => ((IList)Collection)[index] = value; }
        public T this[int index] { get => ((IList<T>)Collection)[index]; set => ((IList<T>)Collection)[index] = value; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
