using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1.Class_Student
{
    class Student
    {
        //FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber.
        //private string firstName;
        //private string lastName;
        //private int age;
        //private int facultyNumber;
        //private string phone;
        //private string email;
        //private IList<int> marks;
        //private int groupNumber;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public string GroupName { get; set; }

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber,string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public override string ToString()
        {
            return string.Format("First name:{0}, Last name:{1}, Age:{2}, Group:{3}, Group Name: {4}", this.FirstName, this.LastName, this.Age, this.GroupNumber, this.GroupName);
        }
    }
}
