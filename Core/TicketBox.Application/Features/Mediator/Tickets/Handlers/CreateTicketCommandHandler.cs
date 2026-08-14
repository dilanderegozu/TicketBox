using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBox.Application.Features.Mediator.Tickets.Commands;
using TicketBox.Domain.Entities;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly TicketBoxContext _context;
        public CreateTicketCommandHandler(TicketBoxContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var values = new Ticket
            {
                EventId = request.EventId,
                AttendeeId = request.AttendeeId,
                Price = request.Price,
                PurchaseDate = request.PurchaseDate,
            };
            await _context.Tickets.AddAsync(values);
            await _context.SaveChangesAsync();
        }
    }
}