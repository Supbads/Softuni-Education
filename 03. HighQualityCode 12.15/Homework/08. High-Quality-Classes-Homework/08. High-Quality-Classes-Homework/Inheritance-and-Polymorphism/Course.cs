namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public abstract class Course
    {
        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = string.Empty;
            this.Students = new List<string>();
        }

        protected Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        protected virtual string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}