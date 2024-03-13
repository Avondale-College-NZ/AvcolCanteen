using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public decimal MenuPrice { get; set; }
        [ForeignKey("CategoryID")]
        public Categories Categories { get; set; }
        public int MenuStock { get; set; }
        public bool MenuSpecial { get; set; }

    }
}
