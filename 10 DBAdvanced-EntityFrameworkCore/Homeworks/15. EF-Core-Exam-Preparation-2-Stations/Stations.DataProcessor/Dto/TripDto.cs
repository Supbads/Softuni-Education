namespace Stations.DataProcessor.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class TripDto
    {
        public string Train { get; set; }
        [Required]
        public string OriginStation { get; set; }
        [Required]
        public string DestinationStation { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]
        public string ArrivalTime { get; set; }

        public string Status { get; set; } = "OnTime";

        public string TimeDifference { get; set; }


        /*
        "Train": "BL436170",
        "OriginStation": "Chateaubelair",
        "DestinationStation": "Bystre",
        "DepartureTime": "02/01/2017 01:00",
        "ArrivalTime": "07/01/2017 01:30",
        "Status": "Early",
        "TimeDifference": "07:19"
        */
    }
}