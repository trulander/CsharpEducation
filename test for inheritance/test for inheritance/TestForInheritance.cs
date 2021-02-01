using System;
using System.Collections.Generic;
using System.Text;

namespace test_for_inheritance
{
    class TestForInheritance
    {
        public Base[] _base;
        public int _count;
        public TestForInheritance()
        {
            Console.WriteLine("test for inheritance");
            //Base base = new Base();
            _base = new Base[4];
            _count = 0;
            for (int i = 0; i < 2; i++)
            {
                _base[_count] = new ChildOne("Обьект первого класса № " + i);
                _count++;
            }
            for (int i = 0; i < 2; i++)
            {
                _base[_count] = new ChildTwo("Обьект второго класса № " + i);
                _count++;
            }

            for (int i = 0; i < _base.Length; i++)
            {
                Console.WriteLine(_base[i].WhoIm);
            }
        }
    }
}
