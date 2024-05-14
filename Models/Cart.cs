using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set;}
        public Orders Orders { get; set;}
        
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Products Product { get; set;}
        public int Quantity { get; set;}
    }
}
