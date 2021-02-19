using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Controllers;

namespace ShowCase.Interfases
{
    public interface IItem<T> : ISize<T>
    {
        Guid id { get; set; }
        string name { get; set; }
        DateTime whenCreate { get; set; }
        void Create(T item);
        void Edit(T item);
        void Remove(T item);
    }
}
