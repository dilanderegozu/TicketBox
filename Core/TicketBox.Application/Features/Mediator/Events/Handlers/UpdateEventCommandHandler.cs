using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public UpdateEventCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var values = await _ticketBoxContext.Events.FindAsync(request.EventId);

            if (values == null)
                return;

            values.Title = request.Title;
            values.Description = request.Description;
            values.EventDate = request.EventDate;
            values.Location = request.Location;
            values.Capacity = request.Capacity;
            values.Price = request.Price;
            values.ImageUrl = request.ImageUrl;
            values.CategoryId = request.CategoryId;

            await _ticketBoxContext.SaveChangesAsync(cancellationToken);
        }
    }
}
