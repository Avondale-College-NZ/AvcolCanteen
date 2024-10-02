using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class Products
    {
        [Key] // Primary key
        public int ProductID { get; set; }

        [StringLength(20, ErrorMessage = "Field must be less than 20 characters")] // Limits the amount of data that can be entered                                                                   
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // Defines a specific way of entering data
        [Display(Name = "Product Name")] // Display Name of field
        [Required(ErrorMessage = "Product name is required.")] // Field is required to be filled
        public string Name { get; set; }

        [DataType(DataType.Currency)] // Specifies that the data type is currency
        [Required(ErrorMessage = "Price is required.")] // Field is required to be filled
        [Range(0.5, 50, ErrorMessage = "Please enter a price between 0.5 and 50.")]  // Validates that the price is within a specified range
        public decimal Price { get; set; }
       
        [Display(Name = "Special Price")] // Display Name of field
        [Range(0.5, 50, ErrorMessage = "Please enter a special price between 0.5 and 50.")] // Validates that the price is within a specified range
        public decimal? SpecialPrice { get; set; }

        public string ImageName { get; set; }

        [Required(ErrorMessage = "Product image is required.")] // Field is required to be filled
        [NotMapped] // Excludes this property from being mapped to the database
        [DisplayName("Upload Product Image")] // Display Name of field
        public IFormFile ImageFile { get; set; } // IFormFile allows for file uploads in ASP.NET Core

        [DisplayName("Category")]  // Display Name of field
        [Required(ErrorMessage = "Category ID is required.")] // Field is required to be filled
        [ForeignKey("Category")] // Specifies that this property is a foreign key referencing the Category entity
        public int CategoryID { get; set; }

        public Categories Category { get; set; }

        [Required(ErrorMessage = "Stock amount is required.")] // Field is required to be filled
        [Range(0, 999, ErrorMessage = "Please enter a stock amount between 0 and 999.")] // Validates that the price is within a specified range
        [Display(Name = "Stock Amount")] // Display Name of field
        public int Stock { get; set; }

        public bool Special { get; set; }

        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }
}
