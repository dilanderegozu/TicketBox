using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
