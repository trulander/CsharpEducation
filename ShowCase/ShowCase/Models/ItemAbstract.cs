using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Controllers;

namespace ShowCase.Models
{
    public class ItemAbstract<T> : IItem<T>
    {
        private int _size;
        private int _nameLengthMax = 15;
        private int _nameLengthMin = 1;
        public List<T> Storage { get; set; }        
        public ItemAbstract()
        {
            WhenCreate = DateTime.Now;
            Id = new Guid();
        }
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
        public void ChacgeCost(int newcost)
        {
            Cost = newcost;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime WhenCreate { get; set; }
        public int Cost { get; set; }

        public ItemAbstract(int size)
        {
            _size = size;
            Storage = new List<T>(_size);
        }
        
        public void Create(T item)
        {
            Storage.Add(item);
        }

        public void Remove(T item)
        {
            Storage.Remove(item);
        }

        public bool ReName(string name, out string error)
        {
            if (name.Length <= _nameLengthMax && name.Length >= _nameLengthMin)
            {
                this.Name = name;
                error = "";
                return true;
            }
            error = "Please write new name. It must have length (" + _nameLengthMin + "-" + _nameLengthMax + ") simbols.";
            return false;
        }    }
}