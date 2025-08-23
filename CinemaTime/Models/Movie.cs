namespace CinemaTime.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public int Duration { get; set; }// مدة الفيلم 
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public string PosterUrl { get; set; }// البوستر الأساسي
        public decimal Price { get; set; }

        public float Rating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<MovieImage> AdditionalImages { get; set; }


        public ICollection<MovieActor> MovieActors { get; set; } 

    }
}
