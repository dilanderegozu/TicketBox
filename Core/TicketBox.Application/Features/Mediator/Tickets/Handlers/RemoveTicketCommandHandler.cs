using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBox.Application.Features.Mediator.Tickets.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand>
    {
        private readonly TicketBoxContext _context;
        public RemoveTicketCommandHandler(TicketBoxContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Tickets.FindAsync(request.Id);
            _context.Tickets.Remove(values);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}