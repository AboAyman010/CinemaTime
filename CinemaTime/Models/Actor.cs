namespace CinemaTime.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Photo { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } 

    }
}
