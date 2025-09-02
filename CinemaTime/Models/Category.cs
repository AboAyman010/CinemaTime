using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTime.Models
{
    [Table("Categorys")]
    public class Category
    {
        public int CategoryId { get; set; }
        [Required()]
        [MinLength(3,ErrorMessage ="الحد الادني 3 حروف ")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required()]
        [MinLength(3, ErrorMessage = "الحد الادني 3 حروف ")]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
