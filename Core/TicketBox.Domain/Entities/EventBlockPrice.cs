using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class EventBlockPrice
    {
        public int EventBlockPriceId { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }

        public decimal Price { get; set; }
        public int RemainingCapacity { get; set; }
    }
}
