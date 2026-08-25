using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBox.Application.Features.Mediator.Tickets.Commands;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;


namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
      private readonly IRepository<Ticket> _ticketRepository;

        public CreateTicketCommandHandler(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketRepository.CreateAsync(new Ticket
            {
                EventId = request.EventId,
                AttendeeId = request.AttendeeId,
                Price = request.Price,
                PurchaseDate = request.PurchaseDate,
            });
          
        }
    }
}