using System.ComponentModel.DataAnnotations;

namespace CinemaTime.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required()]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Photo { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } 

    }
}
