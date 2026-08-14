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
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, List<GetTicketQueryResult>>
    {
        private readonly TicketBoxContext _context;
        public GetTicketQueryHandler(TicketBoxContext context)
        {
            _context = context;
        }
        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tickets
                .Select(x => new GetTicketQueryResult
                {
                    EventId = x.EventId,
                    AttendeeId = x.AttendeeId,
                    Price = x.Price,
                    PurchaseDate = x.PurchaseDate,
                    TicketId = x.TicketId
                }).ToListAsync(cancellationToken);

            return values;
        }
    }
}