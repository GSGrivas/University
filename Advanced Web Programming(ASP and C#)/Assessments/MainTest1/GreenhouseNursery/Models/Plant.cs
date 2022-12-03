using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenhouseNursery.Models
{
    public class Plant
    {
        public int PlantId { get; set; }

        [DisplayName("Common name")]
        [Required(ErrorMessage = "Enter common name of the plant.")]
        public string PlantCommonName { get; set; }

        [DisplayName("Scientific name")]
        [Required(ErrorMessage = "Enter scientific name of the plant.")]
        public string PlantScientificName { get; set; }

        [DisplayName("Water need")]
        [Required]
        [Range(1,5, ErrorMessage ="Enter 1, 2, 3, 4 or 5 to indicate water need.")]
        public int PlantWaterNeed { get; set; }
        
        [DisplayName("Price")]
        [Column(TypeName = "money")]
        [Required]
        public decimal PlantPrice { get; set; }


        [DisplayName("Date added")]
        [Required]
        public DateTime PlantDateAdded { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage =" Choose a plant category.")]
        public int? CategoryId { get; set; }

        //Navigation properties
        public Category Category { get; set; }
    }
}
