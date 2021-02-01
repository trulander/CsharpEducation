using System;
using System.Collections.Generic;
using System.Text;

namespace test_for_inheritance
{
    class ChildTwo : Base
    {
        public string FieldTwo { get; set; }
        public int WhoIm = 2;
        public ChildTwo(string field) : base(field)
        {
            FieldOne = field;
        }
    }
}
