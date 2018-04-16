using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Person
{
    class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            this.Age = age;
        }

        public int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > 15)
                {
                    throw new Exception("Child's age must be less than 15!");
                }

                base.Age = value;
            }
        }
    }
}