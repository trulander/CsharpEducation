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
        private int _nameLengthMax = 15;
        private int _nameLengthMin = 1;

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
        public void ChacgeCost(int newcost)
        {
            cost = newcost;
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime whenCreate { get; set; }
        public int cost { get; set; }

        public ItemAbstract(int size)
        {
            _size = size;
            storage = new List<T>(_size);
        }
        
        public void Create(T item)
        {
            storage.Add(item);
        }

        public void Remove(T item)
        {
            storage.Remove(item);
        }
        public bool ReName(string name, out string error)
        {
            if (name.Length <= _nameLengthMax && name.Length >= _nameLengthMin)
            {
                this.name = name;
                error = "";
                return true;
            }
            error = "Please write new name. It must have length (" + _nameLengthMin + "-" + _nameLengthMax + ") simbols.";
            return false;
        }    }
}