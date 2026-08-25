using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketBox.Application.Features.Mediator.Events.Commands;
using TicketBox.Application.Features.Mediator.Events.Queries;

namespace TicketBox.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> EventList()
        {
            var values = await _mediator.Send(new GetEventQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("EventList");
        }
    }
}
