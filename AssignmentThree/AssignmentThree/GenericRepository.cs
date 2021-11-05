using System;
using System.Collections.Generic;

namespace AssignmentThree
{
    interface IRepository<T>
    {
        public void Add(T item);
        public void Remove(T item);
        public void Save();
        public IEnumerable<T> GetAll();
        public T GetById(int id);
    }

    class GenericRepository<T> : IRepository<T> where T : class
    {
        private List<T> list;
        public GenericRepository()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public void Save()
        {

        }
        public IEnumerable<T> GetAll()
        {
            return list;
        }

        public T GetById(int id)
        {
            foreach(var item in list)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
