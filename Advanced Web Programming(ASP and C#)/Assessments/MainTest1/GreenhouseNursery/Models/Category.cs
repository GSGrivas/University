using System.Collections.Generic;

namespace GreenhouseNursery.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //Navigation properties
        public ICollection<Plant> Plants { get; set; }
    }
}
