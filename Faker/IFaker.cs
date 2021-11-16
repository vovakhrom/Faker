using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    interface IFaker
    {
        public object Create(Type type);
    }
}
