using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int EventBlockPriceId { get; set; }
        public EventBlockPrice EventBlockPrice { get; set; }

        public string QrToken { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }
    }
}
