using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBox.Application.Features.CQRS.Attendees.Results;
using TicketBox.Persistence.Context;

namespace TicketBox.Application.Features.CQRS.Attendees.Handlers
{
    public class GetAttendeeQueryHandler
    {
        private readonly TicketBoxContext _ticketBoxContext;

        public GetAttendeeQueryHandler(TicketBoxContext ticketBoxContext)
        {
            _ticketBoxContext = ticketBoxContext;
        }
        public async Task<List<GetAttendeeQueryResult>> Handle()
        {
            var values = await _ticketBoxContext.Attendees.Select(x => new GetAttendeeQueryResult
            {
                AttendeeId = x.AttendeeId,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname
            }).ToListAsync();
            return values;
        }
    }
}
