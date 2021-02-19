using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Controllers;

namespace ShowCase.Models
{
    public class ItemAbstract<T> : IItem<T>
    {
        private int _size;
        public List<T> storage { get; set; }

        public ItemAbstract()
        {
            whenCreate = DateTime.Now;
            id = new Guid();
        }
        public bool ChangeSize(int size, out string error)
        {
            if (size <= ISize<int>.maxSize && size >= ISize<int>.minSize)
            {
                if (storage.Count > size)
                {
                    error = "The size must be more then case has items. (" + storage.Count + ")";
                    return false;
                }
                storage.Capacity = size;
                error = "";
                return true;
            }

            error = "Please write new size ("+(storage.Count > 1 ? storage.Count : 1)+"-"+ISize<int>.maxSize+")";
            return false;
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime whenCreate { get; set; }
        
        public ItemAbstract(int size)
        {
            _size = size;
            storage = new List<T>(_size);
        }
        
        public void Create(T item)
        {
            storage.Add(item);
        }

        public void Edit(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            storage.Remove(item);
        }

    }
}