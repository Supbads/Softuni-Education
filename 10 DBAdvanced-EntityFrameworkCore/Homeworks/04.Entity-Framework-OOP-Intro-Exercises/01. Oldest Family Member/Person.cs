namespace _01.Oldest_Family_Member
{
    class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Age);
        }
    }
}
