namespace CinemaTime.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime BookingTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } // محجوز، ملغي، مؤكد
        public Payment Payment { get; set; }

    }
}
