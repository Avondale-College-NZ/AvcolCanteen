using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal? SpecialPrice { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Categories Category { get; set; }
        public int Stock { get; set; }
        public bool Special { get; set; }
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();

    }
}
