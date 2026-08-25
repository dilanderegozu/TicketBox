using MediatR;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IRepository<Event> _eventRepository;

        public UpdateEventCommandHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var value = await _eventRepository.GetByIdAsync(request.EventId);

            if (value is null)
                return;

            value.Title = request.Title;
            value.Description = request.Description;
            value.EventDate = request.EventDate;
            value.Location = request.Location;
            value.Capacity = request.Capacity;
            value.Price = request.Price;
            value.ImageUrl = request.ImageUrl;
            value.CategoryId = request.CategoryId;

            await _eventRepository.UpdateAsync(value);
        }
    }
}