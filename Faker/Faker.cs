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
        
        private string GetRandomString()
        {
            string result = "";
            for (int i = 0; i < stringLength; i++)
                result += (char)r.Next(minChar, maxChar);
            return result;
        }

        private DateTime GetRandomDate()
        {
            DateTime date = minDateTime;
            date = date.AddSeconds(r.Next(maxDateSeconds));
            return date;
        }
        
        private List<object> GetRandomList(Type elementType)
        {
            List<object> result = new List<object>();
            IFaker faker = new Faker();
            for (int i = 0; i < listCount; i++)
                result.Add(faker.Create(elementType));
            return result;
        }
        
        private object CreateRandomObject(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            if (constructors.Length != 0)
            {
                while (true)
                {
                    int num = 0;
                    for (int i = 1; i < constructors.Length; i++)
                        if (constructors[i] != null)
                        {
                            if ((constructors[i] == null) || 
                                (constructors[i].GetParameters().Length > 
                                 constructors[num].GetParameters().Length))
                            {
                                num = i;
                            }
                        }

                    if (constructors[num] == null) break;

                    ParameterInfo[] paramInfo = constructors[num].GetParameters();
                    object[] param = new object[paramInfo.Length];


                    for (int i = 0; i < param.Length; ++i)
                    {
                        Type t = paramInfo[i].ParameterType;
                        param[i] = (new Faker()).Create(t);
                    }

                    object result;
                    try
                    {
                        result = Activator.CreateInstance(type, param);
                        FillFields(result, type);
                        FillProperties(result, type);
                    }
                    catch
                    { 
                        result = null; 
                    }

                    if (result != null)
                        return result;

                    constructors[num] = null;
                }
                return null;
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }

    }
}
