using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Controllers;

namespace ShowCase.Models
{
    public class ItemAbstract<T> : IItem<T>
    {
        private int _size;
        public List<T> Storage { get; set; }
        public bool ChangeSize(int size, out string error)
        {
            if (size <= ISize<int>.maxSize && size >= ISize<int>.minSize)
            {
                if (Storage.Count > size)
                {
                    error = "The size must be more then case has items. (" + Storage.Count + ")";
                    return false;
                }
                Storage.Capacity = size;
                error = "";
                return true;
            }

            error = "Please write new size ("+(Storage.Count > 1 ? Storage.Count : 1)+"-"+ISize<int>.maxSize+")";
            return false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WhenCreate { get; set; }
        public DateTime WhenDelete { get; set; }
        
        public ItemAbstract(int size)
        {
            _size = size;
            Storage = new List<T>(_size);
        }
        
        public void Create(T item)
        {
            Storage.Add(item);
        }

        public void Edit(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            Storage.Remove(item);
        }

    }
}