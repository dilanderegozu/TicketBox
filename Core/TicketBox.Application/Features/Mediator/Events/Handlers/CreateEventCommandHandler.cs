using MediatR;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Application.Interfaces;
using TicketBox.Domain.Entities;


namespace TicketBox.Application.Features.Mediator.Events.Handlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IRepository<Event> _eventsRepository;

        public CreateEventCommandHandler(IRepository<Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

    
        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {

            await _eventsRepository.CreateAsync(new Event
            {
                Title = request.Title,
                Description = request.Description,
                EventDate = request.EventDate,
                Location = request.Location,
                Capacity = request.Capacity,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                CategoryId = request.CategoryId
            });
           
         
        }
    }
}
