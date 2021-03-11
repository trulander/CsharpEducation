using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IItem<T> : ISize<T>
    {
        Guid id { get; set; }
        string name { get; set; }
        DateTime whenCreate { get; set; }
        int cost { get; set; }
        void Create(T item);
        bool ReName(string name, out string error);
        void Remove(T item);

    }
}
