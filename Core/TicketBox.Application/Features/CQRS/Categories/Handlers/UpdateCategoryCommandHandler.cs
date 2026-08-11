using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Categories.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Categories.Handlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public UpdateCategoryCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var result = await _ticketBoxContext.Categories.FindAsync(command.CategoryId);
            result.CategoryName = command.CategoryName;
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
