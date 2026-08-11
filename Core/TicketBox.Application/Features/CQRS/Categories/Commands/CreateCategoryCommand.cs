using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.CQRS.Categories.Commands
{
    public class CreateCategoryCommand
    {
        public string CategoryName { get; set; }
    }
}
