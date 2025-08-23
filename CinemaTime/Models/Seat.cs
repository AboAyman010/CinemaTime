namespace CinemaTime.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int CinemaHallId { get; set; }
        public CinemaHall Hall { get; set; }

        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string SeatType { get; set; } // عادي، VIP
        public bool IsAvailable { get; set; } = true;
    }
}

