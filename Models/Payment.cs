using AvcolCanteen.ValidationAttributes;
using System.ComponentModel; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    // Enum to represent different payment types
    public enum PaymentType
    {
        Cash, 
        [Display(Name = "Credit Card")] // Changes the display name for Credit Card
        CreditCard,
        [Display(Name = "Debit Card")] // Changes the display name for Debit Card
        DebitCard,
        Online
    }
    public class Payment
    {
        // Primary key
        [Key]
        public int PaymentID { get; set; }

        [Required] // Indicates that this field is mandatory
        [Display(Name = "Order ID")] // Changes the display name for the field
        [ForeignKey("Orders")] // Specifies that this field is a foreign key referencing the Orders entity
        public int OrderID { get; set; }

        [Display(Name = "Order Number")] // Changes the display name for the field
        public Orders Orders { get; set; }

        [DateValidator(ErrorMessage = "Enter a valid date")] // Custom validation for date validation
        [DataType(DataType.DateTime)] // Specifies that the data type is DateTime
        [Required(ErrorMessage = "Payment date is required.")] // Indicates that this field is mandatory
        [Display(Name = "Payment Date")] // Changes the display name for the field
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment type is required.")] // Indicates that this field is mandatory
        [Display(Name = "Payment Type")] // Changes the display name for the field
        public PaymentType PaymentType { get; set; } // Enum representing the type of payment
    }
}
