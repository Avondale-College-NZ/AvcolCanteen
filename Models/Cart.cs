using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        [Display(Name = "Order ID")]
        [ForeignKey("Orders")]
        public int OrderID { get; set;}
        public Orders Orders { get; set;}

        [Required]
        [Display(Name = "Product ID")]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Products Product { get; set;}

        [Required]
        public int Quantity { get; set;}
    }
}
