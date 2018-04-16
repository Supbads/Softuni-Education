using System;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public Visitation()
        {
        }

        public Visitation(DateTime date, string comments, int patientId , int doctorId)
        {
            this.Date = date;
            this.Comments = comments;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
        }

        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}