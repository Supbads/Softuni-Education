namespace P01_StudentSystem.Data.Models
{
    using System.Collections.Generic;
    using System;

    public class Course
    {
        public Course()
        {
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();

        public ICollection<StudentCourse> StudentsEnrolled { get; set; } = new List<StudentCourse>();
    }
}