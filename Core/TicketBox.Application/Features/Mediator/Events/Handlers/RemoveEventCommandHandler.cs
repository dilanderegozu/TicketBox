using MediatR;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class RemoveEventCommandHandler : IRequestHandler<RemoveEventCommand>
    {
        private readonly IRepository<Event> _eventRepository;

        public RemoveEventCommandHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var value = await _eventRepository.GetByIdAsync(request.Id);
            await _eventRepository.RemoveAsync(value);
        }
    }
}