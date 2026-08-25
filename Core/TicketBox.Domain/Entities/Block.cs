using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Domain.Entities
{
    public class Block
    {
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public int Capacity { get; set; }      
        public int VenueId { get; set; }          
        public Venue Venue { get; set; }
    }
}
