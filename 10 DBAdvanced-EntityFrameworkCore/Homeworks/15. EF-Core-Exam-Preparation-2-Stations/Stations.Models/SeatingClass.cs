using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class SeatingClass
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        //text with an exact length of 2 (no more, no less), (required, unique)
        //might need to check solution
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }
    }
}