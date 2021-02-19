using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class Product<T> : ItemAbstract<T>
    {
        public string Marker { get;}
        private int _nameLengthMax = 15;
        private int _nameLengthMin = 1;
        public Product(int size) : base(size)
        {
            Marker = "*";
            id = Guid.NewGuid();
            whenCreate = DateTime.Now;
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
        }
    }
}
