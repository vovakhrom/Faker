using System;
using System.Collections.Generic;

namespace Faker
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            IFaker faker = new Faker();



            /////////////////////////////Primitive types test
            int a = 0;
            a = (int)faker.Create(typeof(int));

            string b = "";
            b = (string)faker.Create(typeof(string));

            DateTime c = DateTime.MinValue;
            c = (DateTime)faker.Create(typeof(DateTime));

            double d = 0;
            d = (double)faker.Create(typeof(double));

            if ((a == 0) || (b == "") || (c == DateTime.MinValue) || (d == 0))
                Console.WriteLine("Primitive types test FAILED");
            else
                Console.WriteLine("Primitive types test OK");
            /////////////////////////////Primitive types test



            /////////////////////////////List test
            bool isOk = true;
            List<object> f = (List<object>)faker.Create(typeof(List<int>));
            if (f.Count == 0)
            {
                Console.WriteLine("List test FAILED");
                isOk = false;
            } else
            foreach (object e in f)
            {
                if ((int)e == 0)
                {
                    Console.WriteLine("List test FAILED");
                    isOk = false;
                    break;
                }
            }
            if (isOk) Console.WriteLine("List test OK");
            /////////////////////////////List test



            /////////////////////////////Struct test
            TestStruct2 g;
            g = (TestStruct2)faker.Create(typeof(TestStruct2));
            if (g == null)
                Console.WriteLine("Struct test FAILED");
            else
                Console.WriteLine("Struct test OK");
            /////////////////////////////Struct test



            /////////////////////////////Struct more arguments
            TestStruct h;
            h = (TestStruct)faker.Create(typeof(TestStruct));
            if (h.b != ";;;")
                Console.WriteLine("Struct more arguments test FAILED");
            else
                Console.WriteLine("Struct more arguments test OK");
            /////////////////////////////Struct more arguments



            /////////////////////////////Class test
            DateTime j = (DateTime)Activator.CreateInstance(typeof(DateTime));
            TestClass i;
            i = (TestClass)faker.Create(typeof(TestClass));
            if ((i.b != "xyz") || (i.a == 0) || (i.c == j) || (i.A == 0))
                Console.WriteLine("Class test FAILED");
            else
                Console.WriteLine("Class test OK");
            /////////////////////////////Class test
        }
    }
}
