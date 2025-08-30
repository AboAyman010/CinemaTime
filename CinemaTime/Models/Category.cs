using System.ComponentModel.DataAnnotations;

namespace CinemaTime.Models
{
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
