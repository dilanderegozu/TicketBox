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
    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, GetByIdEventQueryResult>
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetByIdEventQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task<GetByIdEventQueryResult> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
        {
            var value = await _ticketBoxContext.Events
                .Where(x => x.EventId == request.Id)
                .Select(x => new GetByIdEventQueryResult
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
                }).FirstOrDefaultAsync(cancellationToken);
            return value;
        }
    }
}