using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(string name, string specialty)
        {
            this.Name = name;
            this.Specialty = specialty;
        }

        public int DoctorId { get; set; }
        public string Name { get; set; }

        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();

    }
}