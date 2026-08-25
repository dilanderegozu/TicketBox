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
    public class GetByIdTicketQueryHandler : IRequestHandler<GetByIdTicketQuery, GetByIdTicketQueryResult>
    {

        private readonly IRepository<Ticket> _ticketRepository;

        public GetByIdTicketQueryHandler(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<GetByIdTicketQueryResult> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
        {
            var values = await _ticketRepository.GetByIdAsync(request.Id);
            return new GetByIdTicketQueryResult
            {
                EventId = values.EventId,
                AttendeeId = values.AttendeeId,
                Price = values.Price,
                TicketId = values.TicketId,
                PurchaseDate = values.PurchaseDate
            };
            
        }
    }
}