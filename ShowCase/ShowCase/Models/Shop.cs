﻿using System;
using ShowCase.Controllers;
using ShowCase.Interfases;

namespace ShowCase.Models
{
    public class Shop<T> : ItemAbstract<T>
    {
        public Shop(int size) : base(size)
        {
            id = Guid.NewGuid();
            whenCreate = DateTime.Now;
        }
    }
}