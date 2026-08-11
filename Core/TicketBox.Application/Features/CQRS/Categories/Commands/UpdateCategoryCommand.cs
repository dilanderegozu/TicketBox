using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Categories.Commands
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
