using System;
using System.Collections.Generic;
using System.Text;

namespace programm_class
{
    public class Person
    {
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
        // Fields
        private string _name;
        private int _age;

        //private static string _name;

        // Property
        // упрощение написания геттеров и сеттеров
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        // Methods

        //public  void SetName(string name)
        //{
        //    _name = name;
        //}
        //public string GetName()
        //{
        //    return _name;
        //}
        public void PrintName()
        {
            Console.WriteLine(_name);
        }
    }
}
