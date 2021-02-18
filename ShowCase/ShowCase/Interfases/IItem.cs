using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Controllers;

namespace ShowCase.Interfases
{
    public interface IItem<T> : ISize<T>
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime WhenCreate { get; set; }
        DateTime WhenDelete { get; set; }
        void Create(T item);
        void Edit<T>(T item);
        void Remove<T>(T item);
    }
}
