namespace GloboTicket.TicketManagement.Api.Controllers
{
    using GloboTicket.TicketManagement.Api.Utility;
    using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
    using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
    using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var result = _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
        {
            var query = new GetEventDetailQuery() { Id = id};
            return Ok(await _mediator.Send(query));

        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createCommand)
        {
            var id = await _mediator.Send(createCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents() {

            var fileDto = await _mediator.Send(new GetEventsExportQuery());
            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }

    }
}
