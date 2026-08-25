using MediatR;
using TicketBox.Application.Features.Mediator.Tickets.Commands;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;

namespace TicketBox.Application.Features.Mediator.Tickets.Handlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
       private readonly IRepository<Ticket> _ticketRepository;

        public UpdateTicketCommandHandler(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var value = await _ticketRepository.GetByIdAsync(request.TicketId);
            if (value is null)
                return;

            value.EventId = request.EventId;
            value.AttendeeId = request.AttendeeId;
            value.PurchaseDate = request.PurchaseDate;
            value.Price = request.Price;

            await _ticketRepository.UpdateAsync(value);
        }
    }
}