using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? UserId { get; set; }        
        public AppUser? User { get; set; }

        public string BuyerName { get; set; }
        public string BuyerSurname { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerPhone { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
