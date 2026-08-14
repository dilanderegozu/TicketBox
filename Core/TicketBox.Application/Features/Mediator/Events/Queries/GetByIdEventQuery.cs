using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.Mediator.Events.Results;

namespace TicketBox.Application.Features.Mediator.Events.Queries
{
    public class GetByIdEventQuery : IRequest<GetByIdEventQueryResult>
    {
        public int Id { get; set; }
    }
}
