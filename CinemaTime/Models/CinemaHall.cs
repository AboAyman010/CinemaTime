namespace CinemaTime.Models
{
    public class CinemaHall
    {
        public int CinemaHallId { get; set; }
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Location { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Seat> Seats { get; set; }

    }
}
