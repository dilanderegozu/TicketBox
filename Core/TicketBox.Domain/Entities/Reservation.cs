using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int EventBlockPriceId { get; set; }
        public EventBlockPrice EventBlockPrice { get; set; }

        public string? UserId { get; set; }
        public string SessionId { get; set; }    

        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
