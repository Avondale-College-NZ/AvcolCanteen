using AvcolCanteen.ValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public enum PaymentType
    {
        Cash,
        [Display(Name = "Credit Card")] // changes the display name to this
        CreditCard,
        [Display(Name = "Debit Card")] // changes the display name to this
        DebitCard,
        Online
    }
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [Display(Name = "Order ID")] // changes the display name to this
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [Display(Name = "Order Number")] // changes the display name to this

        public Orders Orders { get; set; }

        [DateValidator(ErrorMessage = "Enter a valid date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Payment date is required.")]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment type is required.")]
        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; }
    }
}
