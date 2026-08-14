using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBox.Application.Features.Mediator.Events.Results;
using TicketBox.Application.Features.Mediator.Tickets.Queries;
using TicketBox.Application.Features.Mediator.Tickets.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class GetByIdTicketQueryHandler : IRequestHandler<GetByIdTicketQuery, GetByIdTicketQueryResult>
    {
        private readonly TicketBoxContext _context;
        public GetByIdTicketQueryHandler(TicketBoxContext context)
        {
            _context = context;
        }
        public async Task<GetByIdTicketQueryResult> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Tickets
               .Where(x => x.TicketId == request.Id)
               .Select(x => new GetByIdTicketQueryResult
               {
                   EventId = x.EventId,
                   AttendeeId = x.AttendeeId,
                   Price = x.Price,
                   TicketId = x.TicketId,
                   PurchaseDate = x.PurchaseDate
               }).FirstOrDefaultAsync(cancellationToken);
            return value;
        }
    }
}