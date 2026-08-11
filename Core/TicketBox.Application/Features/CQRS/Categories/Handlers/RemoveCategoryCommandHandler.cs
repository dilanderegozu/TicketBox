using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Categories.Commands;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Categories.Handlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public RemoveCategoryCommandHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _ticketBoxContext.Categories.FindAsync(command.CategoryId);
            _ticketBoxContext.Categories.Remove(value);
            await _ticketBoxContext.SaveChangesAsync();
        }
    }
}
