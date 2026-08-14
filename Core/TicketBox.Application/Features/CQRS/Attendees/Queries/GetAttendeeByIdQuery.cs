using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Attendees.Queries
{
    public class GetAttendeeByIdQuery
    {
        public int AttendeeId { get; set; }
    }
}
