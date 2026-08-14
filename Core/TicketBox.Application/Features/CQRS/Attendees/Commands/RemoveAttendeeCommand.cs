using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Attendees.Commands
{
    public class RemoveAttendeeCommand
    {
        public int AttendeeId { get; set; }
    }
}
