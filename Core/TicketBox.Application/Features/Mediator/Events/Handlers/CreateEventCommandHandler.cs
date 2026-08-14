using MediatR;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Domain.Entities;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public CreateEventCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var values = new Event
            {
                Title = request.Title,
                Description = request.Description,
                EventDate = request.EventDate,
                Location = request.Location,
                Capacity = request.Capacity,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId
            };
            await _ticketBoxContext.Events.AddAsync(values);
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
