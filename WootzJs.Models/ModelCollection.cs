using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace WootzJs.Models
{
    public delegate void ModelCollectionEvent<in T>(int index, T item);

    public static class ModelCollectionExtensions
    {
        public static ModelCollection<T> ToModelCollection<T>(this IEnumerable<T> source) where T : Model<T>
        {
            return new ModelCollection<T>(source);
        }
    }

    public class ModelCollection<T> : IEnumerable<T> where T : Model<T>
    {
        public event ModelCollectionEvent<T> Added;
        public event ModelCollectionEvent<T> Removed;
        public event ModelCollectionEvent<T> Updated;

        private List<T> storage = new List<T>();

        public ModelCollection()
        {
        }

        public ModelCollection(IEnumerable<T> source)
        {
            foreach (var item in source)
                Add(item);
        }

        public void Add(T item)
        {
            item.PropertyChanged += ItemOnPropertyChanged;
            var index = storage.Count;
            storage.Add(item);
            OnAdded(index, item);
        }

        public void Remove(T item)
        {
            var index = storage.IndexOf(item);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            var item = this[index];
            item.PropertyChanged -= ItemOnPropertyChanged;
            storage.RemoveAt(index);
            OnRemoved(index, item);            
        }

        public int Count
        {
            get { return storage.Count; }
        }

        public T this[int index]
        {
            get { return storage[index]; }
        }

        public void RemoveWhere(Func<T, bool> predicate)
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                var item = this[i];
                if (predicate(item))
                    RemoveAt(i);
            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            T item = (T)sender;
            var index = storage.IndexOf(item);
            OnUpdated(index, item);
        }

        protected virtual void OnAdded(int index, T item)
        {
            if (Added != null)
                Added(index, item);
        }

        protected virtual void OnRemoved(int index, T item)
        {
            if (Removed != null)
                Removed(index, item);
        }

        protected virtual void OnUpdated(int index, T item)
        {
            if (Updated != null)
                Updated(index, item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return storage.GetEnumerator();
        }
    }
}