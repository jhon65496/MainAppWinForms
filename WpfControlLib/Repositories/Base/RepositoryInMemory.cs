using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfControlLib.Models.Interfaces;
using WpfControlLib.Repositories.Interfaces;
using WpfControlLib.Data;
using System.Diagnostics;

namespace WpfControlLib.Repositories.Base
{
    // abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    abstract class RepositoryInMemory<T> where T : IEntity
    {
        // private readonly List<T> _Items = new List<T>();
        private readonly ObservableCollection<T> _Items = new ObservableCollection<T>();
        private int _LastId;

        protected RepositoryInMemory() { }

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        public void Add(T item)
        {
            // if (item is null) throw new ArgumentNullException(nameof(item));
            // if (item != null) throw new ArgumentNullException(nameof(item));

            if (_Items.Contains(item)) return;

            item.Id = ++_LastId;
            _Items.Add(item);
        }


        public void LoadData(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }


        public IEnumerable<T> GetAll() => _Items;

        public bool Remove(T item) => _Items.Remove(item);
        

        public void Clear() => _Items.Clear();

        //public void Update(int id, T item)
        //{
        //    // if (item is null) throw new ArgumentNullException(nameof(item));
        //    if (item != null) throw new ArgumentNullException(nameof(item));
        //    if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

        //    if (_Items.Contains(item)) return;

        //    // var db_item = ((IRepository<T>)this).Get(id);
        //    var db_item = this.Get(id);
        //    if (db_item is null)
        //        throw new InvalidOperationException("Редактируемый элемент не найден в репозитории");

        //    Update(item, db_item);
        //}

        protected abstract void Update(T Source, T Destination);
        protected void Update2(T Source, T Destination)
        {
            int indexItem = _Items.IndexOf(_Items.First(c => c.Id == Source.Id));
            if (indexItem > -1)
                _Items[indexItem] = Destination;
        
        }
        protected void Update3(int id, T Destination)
        {
            int indexItem = _Items.IndexOf(_Items.First(c => c.Id == id));
            if (indexItem > -1)
                _Items[indexItem] = Destination;

        }

    }
}
