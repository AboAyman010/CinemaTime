namespace CinemaTime.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int HallId { get; set; }
        public CinemaHall Hall { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
