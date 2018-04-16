namespace Problem_1.Class_Student
{
    class StudentSpecialties
    {
        public string Speciality { get; set; }

        public int FacultyNumber { get; set; }

        public StudentSpecialties(string studentSpeciality, int facultyNumber)
        {
            this.Speciality = studentSpeciality;
            this.FacultyNumber = facultyNumber;
        }
    }
}
