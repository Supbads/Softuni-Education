using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Persons
{
    class Person
    {
        private string name;
        private uint age;
        private string email;

        public uint Age
        {
            get { return this.age;} 
            set
            {
                if (value == null) 
                {
                    throw new ArgumentNullException("age cannot be null", "age");
                }
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("age must be in the rage 1-100", "age");
                }
                this.age = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != null|| value.Length!=0)
                {
                    this.name = value;
                }
                else 
                {
                    throw new ArgumentException("name cannot be null or empty", "name");
                }
            }
        }
        public string Email
        {
            get { return this.email; }
            set 
            {
                if (value.Contains("@") || value == null)
                {
                    this.email = value;
                }
                else 
                {
                    throw new ArgumentException("email","email must be blank or must contain @");
                }
            }
        }


        public Person(string name, uint age, string email)
        {
            this.Age = age;
            this.Name = name;
            this.Email = email;
        }
        public Person(string name, uint age):this(name,age,null)
        {      
        }

        public Person()
        {

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.email != null)
            {
                sb.AppendLine("Hello !\n" + "I am " + name + " and my age is " + age + ".\n" + "Send me a message at: " + email);
            
            }                
            else 
            {
                sb.AppendLine("Hello !\n" + "I am " + name + " and my age is " + age + ".\n");
            }
            return sb.ToString();
        }

    }
}
