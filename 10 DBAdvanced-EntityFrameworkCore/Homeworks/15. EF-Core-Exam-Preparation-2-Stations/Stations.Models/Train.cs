using System.ComponentModel.DataAnnotations;
using Stations.Models.Enums;

namespace Stations.Models
{
    using System.Collections.Generic;

    public class Train
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}