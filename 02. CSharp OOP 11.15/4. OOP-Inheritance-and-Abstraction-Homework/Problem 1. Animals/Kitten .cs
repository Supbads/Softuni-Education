using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Animals
{
    class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age) : base(name, age, gender)
        {
        }
    }
}
