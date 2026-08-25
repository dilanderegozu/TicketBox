using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.Mediator.Events.Queries;
using TicketBox.Application.Features.Mediator.Events.Results;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;


namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, GetByIdEventQueryResult>
    {
       private readonly IRepository<Event> _eventRepository;

        public GetByIdEventQueryHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<GetByIdEventQueryResult> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
        {
            var value = await _eventRepository.GetByIdAsync(request.Id);
            return new GetByIdEventQueryResult
            {
                EventId = value.EventId,
                Title = value.Title,
                Description = value.Description,
                EventDate = value.EventDate,
                Location = value.Location,
                Capacity = value.Capacity,
                Price = value.Price,
                ImageUrl = value.ImageUrl,
                CategoryId = value.CategoryId
            };
        }
    }
}