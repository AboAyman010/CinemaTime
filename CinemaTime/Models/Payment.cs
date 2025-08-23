namespace CinemaTime.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // بطاقة، محفظة، نقدي
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // ناجح، فشل، معلق
    }
}
