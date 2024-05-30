using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        [Required]
        [Display(Name = "Order ID")] // changes the display name to this
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        public Orders Orders { get; set; }

        [Required] // requires user to fill in
        [Display(Name = "Payment Date")] // changes the display name to this
        public DateTime PaymentDate { get; set; }

        [Required]
        [Display(Name = "Payment Type")] // changes the display name to this
        public string PaymentType { get; set; }
    }
}
