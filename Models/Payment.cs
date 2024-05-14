using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        public Orders Orders { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
    }
}
