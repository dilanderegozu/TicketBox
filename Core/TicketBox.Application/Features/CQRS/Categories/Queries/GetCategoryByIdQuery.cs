using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Categories.Queries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }
    }
}
