using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBox.Application.Features.Mediator.Events.Commands
{
    public class RemoveEventCommand:IRequest
    {
        public int Id { get; set; }
    }
}
