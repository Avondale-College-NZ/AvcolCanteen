using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Cart
    {
        // Primary key
        [Key]
        public int CartID { get; set; }

        [Required(ErrorMessage = "Order ID is required.")] // Indicates that this field is mandatory
        [Display(Name = "Order ID")] // Specifies the display name for the field
        [ForeignKey("Orders")] // Establishes a foreign key relationship with the Orders table
        public int OrderID { get; set; }

        public Orders Orders { get; set; }

        [Required(ErrorMessage = "Product ID is required.")] // Indicates that this field is mandatory
        [Display(Name = "Product ID")] // Specifies the display name for the field
        [ForeignKey("Product")] // Establishes a foreign key relationship with the Products table
        public int ProductID { get; set; }

        public Products Product { get; set; }

        [Range(1, 10, ErrorMessage = "Please enter a total amount between 1 and 10.")] // Limits the quantity to between 1 and 10
        [Required(ErrorMessage = "Quantity is required.")] // Indicates that this field is mandatory
        public int Quantity { get; set; }
    }
}
