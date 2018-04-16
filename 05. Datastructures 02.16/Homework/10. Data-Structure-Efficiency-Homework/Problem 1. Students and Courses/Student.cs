namespace Problem_1.Students_and_Courses
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            if (this.LastName.CompareTo(other.LastName) > 0)
            {
                return 1;
            }

            if (this.LastName.CompareTo(other.LastName) < 0)
            {
                return -1;
            }

            if (this.FirstName.CompareTo(other.FirstName) > 0)
            {
                return 1;
            }

            if (this.FirstName.CompareTo(other.FirstName) < 0)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}