﻿namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    using MediatR;

    public class CreateEventCommand: IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name {Name}; Price: {Price}; By: {Artist}; on: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}