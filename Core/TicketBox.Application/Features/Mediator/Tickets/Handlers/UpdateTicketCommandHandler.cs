using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Application.Features.Mediator.Tickets.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly TicketBoxContext _context;
        public UpdateTicketCommandHandler(TicketBoxContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Tickets.FindAsync(request.TicketId);

            if (values == null)
                return;

            _context.Tickets.Update(values);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}