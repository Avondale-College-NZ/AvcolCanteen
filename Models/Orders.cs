using AvcolCanteen.Areas.Identity.Data;
using AvcolCanteen.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Orders
    {
        // Primary key
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "User email is required.")] // Indicates that this field is mandatory
        [Display(Name = "User Email")] // Changes the display name for the field
        [ForeignKey("AvcolCanteenUser")] // Specifies that this property is a foreign key referencing the AvcolCanteenUser field
        public string AvcolCanteenUserID { get; set; }

        [Display(Name = "User Email")] // Changes the display name for the property
        public AvcolCanteenUser AvcolCanteenUser { get; set; }

        [DateValidator(ErrorMessage = "Enter a valid date")] // Custom validation for date validation
        [DataType(DataType.DateTime)] // Specifies that the data type is DateTime
        [Required(ErrorMessage = "Order date is required.")] // Indicates that this field is mandatory
        [Display(Name = "Order Date")] // Changes the display name for the field
        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; } // Property to indicate the completion status of the order

        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
