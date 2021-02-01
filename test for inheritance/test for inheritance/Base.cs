using System;
using System.Collections.Generic;
using System.Text;

namespace test_for_inheritance
{
    public class Base
    {
        public string FieldOne { get; set; }
        public int WhoIm = 0;
        public Base(string field)
        {
            FieldOne = field;
        }
        public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }
    }
}
