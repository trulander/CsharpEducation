using System;
using ShowCase.Controllers;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class Shop<T> : ItemAbstract<T>
    {
        public Shop(int size) : base(size)
        {
            Id = Guid.NewGuid();
            WhenCreate = DateTime.Now;
        }
    }
}