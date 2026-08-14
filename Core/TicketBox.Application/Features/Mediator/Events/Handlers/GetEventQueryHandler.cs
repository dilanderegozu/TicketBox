using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.Mediator.Events.Queries;
using TicketBox.Application.Features.Mediator.Events.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, List<GetEventQueryResult>>
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetEventQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task<List<GetEventQueryResult>> Handle(
             GetEventQuery request,
             CancellationToken cancellationToken)
        {
            var values = await _ticketBoxContext.Events
                .Select(x => new GetEventQueryResult
                {
                    EventId = x.EventId,
                    Title = x.Title,
                    Description = x.Description,
                    EventDate = x.EventDate,
                    Location = x.Location,
                    Capacity = x.Capacity,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    CategoryId = x.CategoryId
                }).ToListAsync(cancellationToken);

            return values;
        }
    }
}