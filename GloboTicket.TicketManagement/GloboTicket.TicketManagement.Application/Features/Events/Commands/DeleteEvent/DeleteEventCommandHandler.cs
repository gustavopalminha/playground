﻿namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    using AutoMapper;
    using GloboTicket.TicketManagement.Application.Contracts.Persistence;
    using GloboTicket.TicketManagement.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand> 
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
            await _eventRepository.DeleteAsync(eventToDelete);
            return Unit.Value;
        }
    }
}
