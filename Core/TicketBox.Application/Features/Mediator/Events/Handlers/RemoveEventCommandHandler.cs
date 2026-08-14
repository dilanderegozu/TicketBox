using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class RemoveEventCommandHandler:IRequestHandler<RemoveEventCommand>
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public RemoveEventCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var values = await _ticketBoxContext.Events.FindAsync(request.Id);
            _ticketBoxContext.Events.Remove(values);
            await _ticketBoxContext.SaveChangesAsync(cancellationToken);
        }
    }
}
