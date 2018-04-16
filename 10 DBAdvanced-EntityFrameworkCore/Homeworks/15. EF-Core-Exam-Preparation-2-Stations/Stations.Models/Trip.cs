namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;
    using Stations.Models.Enums;
    using System;

    public class Trip
    {
        public int Id { get; set; }

        public int OriginStationId { get; set; }
        [Required]
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        [Required]
        public Station DestinationStation { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        public int TrainId { get; set; }
        [Required]
        public Train Train { get; set; }

        public TripStatus Status { get; set; } = TripStatus.OnTime;

        // not datetime? might need to see solution
        public TimeSpan? TimeDifference { get; set; }
    }
}