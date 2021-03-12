using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Controllers;
using ShowCase.Models;

namespace ShowCase.Interfases
{
    public interface IItem<T> : ISize<T>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime WhenCreate { get; set; }
        int Cost { get; set; }
        void Create(T item);
        bool ReName(string name, out string error);
        void Remove(T item);

    }
}
