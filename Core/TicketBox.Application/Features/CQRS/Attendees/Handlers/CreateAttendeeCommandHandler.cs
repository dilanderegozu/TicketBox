using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Attendees.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Attendees.Handlers
{
    public class CreateAttendeeCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public CreateAttendeeCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task Handle(CreateAttendeeCommand command)
        {
            var attendee = new Domain.Entities.Attendee
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email
            };
            _ticketBoxContext.Attendees.Add(attendee);
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
