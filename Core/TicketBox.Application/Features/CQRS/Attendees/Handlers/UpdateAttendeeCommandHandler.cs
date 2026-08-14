using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Attendees.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Attendees.Handlers
{
    public class UpdateAttendeeCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public UpdateAttendeeCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task Handle(UpdateAttendeeCommand command)
        {
            var value = await _ticketBoxContext.Attendees.FindAsync(command.AttendeeId);
            value.Surname = command.Surname;
            value.Name = command.Name;
            value.Email = command.Email;
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
