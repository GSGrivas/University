﻿
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [RangeAttribute(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price"),
        Column(TypeName = "decimal(8, 2)"), 
        Required]
        public decimal Price { get; set; }

        [DisplayName("Category"),
        Required(ErrorMessage = "Please select a category")]
        public int CategoryID { get; set; }

        
        public Category Category { get; set; }
    }
}
