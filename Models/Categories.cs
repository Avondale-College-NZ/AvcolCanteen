using System.ComponentModel.DataAnnotations;

namespace AvcolCanteen.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [StringLength(25, ErrorMessage = "Field must be less than 25 characters")] // limits the amount of data that can be entered
        [Required(ErrorMessage = "Category name is required.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
