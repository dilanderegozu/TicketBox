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
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, List<GetTicketQueryResult>>
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public GetTicketQueryHandler(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var value = await _ticketRepository.GetAllAsync();
            return value.Select(x => new GetTicketQueryResult
            {
                EventId = x.EventId,
                AttendeeId = x.AttendeeId,
                Price = x.Price,
                PurchaseDate = x.PurchaseDate,
                TicketId = x.TicketId
            }).ToList();
          
        }
    }
}