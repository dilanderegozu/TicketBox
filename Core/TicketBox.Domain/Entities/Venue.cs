using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<Block> Blocks { get; set; }
    }
}
