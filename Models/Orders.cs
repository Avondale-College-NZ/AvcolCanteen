using AvcolCanteen.Areas.Identity.Data;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace AvcolCanteen.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("AvcolCanteenUser") ]
        public string AvcolCanteenUserID { get; set; }
        public AvcolCanteenUser AvcolCanteenUser { get; set; }
        public int TotalPrice { get; set; }
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();

    }
}
