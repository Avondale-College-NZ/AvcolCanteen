using AvcolCanteen.Areas.Identity.Data;
using AvcolCanteen.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "User email is required.")]
        [Display(Name = "User Email")]
        [ForeignKey("AvcolCanteenUser")]
        public string AvcolCanteenUserID { get; set; }

        [Display(Name = "User Email")]
        public AvcolCanteenUser AvcolCanteenUser { get; set; }

        [DateValidator(ErrorMessage = "Enter a valid date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Order date is required.")]
        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }


        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
