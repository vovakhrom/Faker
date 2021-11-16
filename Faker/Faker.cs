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
    }
}
