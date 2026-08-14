using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Attendees.Queries;
using TicketBox.Application.Features.CQRS.Attendees.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Attendees.Handlers
{
    public class GetAttendeeByIdQueryHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetAttendeeByIdQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task<GetByIdAttendeeQueryResult> Handle(GetAttendeeByIdQuery query)
        {
            var values = await _ticketBoxContext.Attendees.Where(x => x.AttendeeId == query.AttendeeId).Select(x => new GetByIdAttendeeQueryResult
            {
                AttendeeId = x.AttendeeId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email
            }).FirstOrDefaultAsync();
            return values;
        }
    }
}
