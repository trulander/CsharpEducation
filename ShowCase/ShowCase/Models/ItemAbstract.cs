using System;
using System.Collections.Generic;
using ShowCase.Interfases;
using ShowCase.Controllers;

namespace ShowCase.Models
{
    public class ItemAbstract<T> : IItem<T>
    {
        private int _size;

        public List<T> Size { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WhenCreate { get; set; }
        public DateTime WhenDelete { get; set; }
        
        public void Create<T1>(T1 item)
        {
            throw new NotImplementedException();
        }

        public void Edit<T1>(T1 item)
        {
            throw new NotImplementedException();
        }

        public void Remove<T1>(T1 item)
        {
            throw new NotImplementedException();
        }

        public ItemAbstract(int size)
        {
            _size = size;
        }
 
    }
}