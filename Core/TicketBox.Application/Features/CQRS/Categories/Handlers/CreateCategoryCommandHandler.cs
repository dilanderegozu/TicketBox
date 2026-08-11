using TicketBox.Application.Features.CQRS.Categories.Commands;
using TicketBox.Domain.Entities;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Categories.Handlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public CreateCategoryCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryName = command.CategoryName,
              
            };
            _ticketBoxContext.Categories.Add(category);
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
