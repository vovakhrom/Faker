using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class TestClass
    {
        public int a;
        public string b;
        public DateTime c;

        public int A { get; set; }

        public TestClass (int a)
        {
            this.a = a;
            this.b = "abc";
        }

        public TestClass(int a, DateTime c)
        {
            this.a = a;
            this.b = "xyz";
        }
    }
}
