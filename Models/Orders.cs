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

        [Required(ErrorMessage = "Total price is required.")]
        public int TotalPrice { get; set; }

        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
