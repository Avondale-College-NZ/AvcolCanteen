using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(20, ErrorMessage = "Field must be less than 20 characters")] // limits the amount of data that can be entered                                                                   
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.5, 50, ErrorMessage = "Please enter a price between 0.5 and 50.")]
        public decimal Price { get; set; }

        [Display(Name = "Special Price")]
        [Range(0.5, 50, ErrorMessage = "Please enter a special price between 0.5 and 50.")]
        public decimal? SpecialPrice { get; set; }

        public string ImageName { get; set; }

        [Required(ErrorMessage = "Product image is required.")]
        [NotMapped]
        [DisplayName("Upload Product Image")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Category ID is required.")]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Categories Category { get; set; }

        [Required(ErrorMessage = "Stock amount is required.")]
        [Range(0, 999, ErrorMessage = "Please enter a stock amount between 0 and 999.")]
        [Display(Name = "Stock Amount")]
        public int Stock { get; set; }

        public bool Special { get; set; }

        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
