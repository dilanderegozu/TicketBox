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
    public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand>
    {
       private readonly IRepository<Ticket> _ticketRepository;

        public RemoveTicketCommandHandler(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            var values = await _ticketRepository.GetByIdAsync(request.Id);
            await _ticketRepository.RemoveAsync(values);
        }
    }
}