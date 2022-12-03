using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2")]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
