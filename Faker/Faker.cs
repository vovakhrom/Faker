using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Faker
{
    class Faker: IFaker
    {
        private Random r = new Random();

        private const int stringLength = 100;
        private const char minChar = '0';
        private const int maxChar = 'z';
        private DateTime minDateTime = new DateTime(1970, 1, 1);
        private const int maxDateSeconds = 60 * 365 * 24 * 60 * 60;
        private const int listCount = 10;

        public Faker()
        {
        }
        
        public object Create(Type type)
        {
            //return type.BaseType;
            switch(type.Name)
            {
                case "Int32":
                {
                    return r.Next();
                }
                case "Double":
                case "Single":
                {
                    return r.NextDouble();
                }
                case "String":
                {
                    return GetRandomString();
                }
                case "DateTime":
                {
                    return GetRandomDate();
                }
                case "List`1":
                {
                    return GetRandomList(type.GetGenericArguments().Single());
                } break;

                default:
                {
                    return CreateRandomObject(type);
                }
            }
        }
    }
}
