using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [Range(1, 1000, ErrorMessage = "Please provide a number in the range 1-1000")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
