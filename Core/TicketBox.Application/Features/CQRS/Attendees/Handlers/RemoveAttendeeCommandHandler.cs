using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Attendees.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Attendees.Handlers
{
    public class RemoveAttendeeCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public RemoveAttendeeCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(RemoveAttendeeCommand command)
        {
            var value = await _ticketBoxContext.Attendees.FindAsync(command.AttendeeId);
            _ticketBoxContext.Attendees.Remove(value);
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
