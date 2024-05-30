using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required] // requires user to fill in 
        public string Name { get; set; }

        [Required] // requires user to fill in 
        [Range(0, 999, ErrorMessage = "Please enter a 6-digit number")] // limits the amount of data that can be entered
        public decimal Price { get; set; }

        [Range(0, 999, ErrorMessage = "Please enter a 6-digit number")] // limits the amount of data that can be entered
        [Display(Name = "Special Price")]
        public decimal? SpecialPrice { get; set; }

        public string ImageName { get; set; }

        [Required] // requires user to fill in 
        [NotMapped]
        [DisplayName("Upload Product Image")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Category")]
        [Required] // requires user to fill in 
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Categories Category { get; set; }

        [Required] // requires user to fill in 
        [Range(0, 999, ErrorMessage = "Please enter a 6-digit number")] // limits the amount of data that can be entered
        [Display(Name = "Stock Amount")]
        public int Stock { get; set; }
        public bool Special { get; set; }
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();

    }
}
