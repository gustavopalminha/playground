﻿namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    using AutoMapper;
    using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
    using GloboTicket.TicketManagement.Application.Contracts.Persistence;
    using GloboTicket.TicketManagement.Application.Models.Mail;
    using GloboTicket.TicketManagement.Domain.Entities;
    using MediatR;

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            IEmailService emailService
        ) { 
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            @event = await _eventRepository.AddAsync( @event);

            SendEmail(request);

            return @event.EventId;
        }

        private async void SendEmail (CreateEventCommand request)
        {
            var email = new Email()
            {
                To = "gill@snowball.be",
                Body = $"A new event was created:{request}",
                Subject = "A new event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Just log the error. Don't stop the API from working normaly
            }
        }
    }
}