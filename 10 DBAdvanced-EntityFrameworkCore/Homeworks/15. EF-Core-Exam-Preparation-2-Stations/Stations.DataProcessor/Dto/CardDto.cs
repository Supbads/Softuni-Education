using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    using System.ComponentModel.DataAnnotations;
    [XmlType("Card")]
    public class CardDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public string CardType { get; set; } = "Normal";

    }
}