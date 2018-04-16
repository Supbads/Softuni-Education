using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Animals
{
    class Tomcat : Cat
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) : base(name, age, gender)
        {
        }
    }
}
