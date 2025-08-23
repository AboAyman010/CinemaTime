namespace CinemaTime.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
