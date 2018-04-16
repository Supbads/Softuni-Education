using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstStudentDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondStudentDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            bool isStudentOlderThanOther = firstStudentDate > secondStudentDate;

            return isStudentOlderThanOther;
        }
    }
}
