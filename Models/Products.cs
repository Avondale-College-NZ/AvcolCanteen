using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SpecialPrice { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Categories Categories { get; set; }
        public int Stock { get; set; }
        public bool Special { get; set; }

    }
}
