namespace _02.Creating_Constructors
{
    class Person
    {
        public Person() : this("No name", 1)
        {
            
        }

        //public Person(string name = "No name", int age = 1)
        //{
        //    Name = name;
        //    Age = age;
        //}

        public Person(string name, int age)
        {
            Name = name;
            Age = age;

        }

        public Person(int age) : this("No name", age)
        {

        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}