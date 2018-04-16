using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Stations.Models.Enums;

namespace Stations.Models
{
    public class CustomerCard
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        //integer between 0 and 120
        [Range(0,120)]
        public int Age { get; set; }

        public CardType Type { get; set; } = CardType.Normal;

        public ICollection<Ticket> BoughtTickets { get; set; }
    }
}