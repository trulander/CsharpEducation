using System;
using System.Collections.Generic;
using System.Text;

namespace test_for_inheritance
{
    class ChildOne : Base
    {
        public string FieldTwo { get; set; }
        public int WhoIm = 1;
        public ChildOne(string field) : base(field)
        {
            FieldOne = field;
            Console.WriteLine("Object ChildOne created;");
        }
        public void MethodTwo(string value)
        {
            FieldTwo = value;
        }
    }
}
