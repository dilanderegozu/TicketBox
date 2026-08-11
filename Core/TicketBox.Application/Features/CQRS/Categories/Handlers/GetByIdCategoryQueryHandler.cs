using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Categories.Queries;
using TicketBox.Application.Features.CQRS.Categories.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Categories.Handlers
{
    public class GetByIdCategoryQueryHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetByIdCategoryQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task<GetByIdCategoryQueryResult> Handle (GetCategoryByIdQuery query)
        {
            var value = await _ticketBoxContext.Categories.Where(x => x.CategoryId == query.CategoryId).Select(x => new GetByIdCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).FirstOrDefaultAsync();
            return value;
        }
    }
}
