﻿using ShowCase.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using ShowCase.Controllers;

namespace ShowCase.Models
{
    public class Case<T> : ItemAbstract<T>
    {
        public Case(int size) : base(size)
        {
            id = Guid.NewGuid();
            whenCreate = DateTime.Now;
        }
    }
}
