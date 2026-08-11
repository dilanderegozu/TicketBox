using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Categories.Results
{
    public class GetByIdCategoryQueryResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
