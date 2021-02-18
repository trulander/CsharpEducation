﻿using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class Product<T> : ItemAbstract<T>
    {
        public string Marker { get; set; }
        public Product(int size) : base(size)
        {
            Marker = "*";
        }
    }
}
