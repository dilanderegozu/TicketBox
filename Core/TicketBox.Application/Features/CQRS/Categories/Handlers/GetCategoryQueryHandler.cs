using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Categories.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Categories.Handlers
{
    public class GetCategoryQueryHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetCategoryQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        } 
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _ticketBoxContext.Categories.Select(x=> new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToListAsync();
            return values;  
        }
    }
}
