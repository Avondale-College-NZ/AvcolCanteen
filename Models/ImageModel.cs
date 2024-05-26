using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolCanteen.Models
{
    public class ImageModel
    {
        [Key]
        public int ImageID { get; set; }
        public string Title { get; set; }
        
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

    }
}
