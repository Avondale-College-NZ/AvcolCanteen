using System.ComponentModel.DataAnnotations;

namespace AvcolCanteen.Models
{
    public class Categories
    {
        // Primary key
        [Key]
        public int CategoryID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [StringLength(25, ErrorMessage = "Field must be less than 25 characters")] // limits the amount of data that can be entered
        [Required(ErrorMessage = "Category name is required.")] // Indicates that this field is mandatory
        [Display(Name = "Category Name")]  // Changes the display name for the field
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
