using System.ComponentModel.DataAnnotations;

namespace AvcolCanteen.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
