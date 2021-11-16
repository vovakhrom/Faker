using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class TestStruct
    {
        public int a;
        public string b;
        public DateTime c;

        public TestStruct()
        {
            this.b = "123";

        }

        public TestStruct(int a)
        {
            this.a = a;
            this.b = ";;;";
            this.c = DateTime.Now;
        }
    }
}
