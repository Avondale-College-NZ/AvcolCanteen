using AvcolCanteen.Areas.Identity.Data;
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

        public AvcolCanteenUser AvcolCanteenUser { get; set; }

        [Range(0, 999, ErrorMessage = "Please enter a total amount between 0 and 999.")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Total price is required.")]
        public int TotalPrice { get; set; }

        //[DataType(DataType.DateTime)]
        //[Required(ErrorMessage = "Order date is required.")]
        //[Display(Name = "Order Date")]
        //public DateTime Date { get; set; }

        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
