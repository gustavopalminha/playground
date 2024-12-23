﻿namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    using GloboTicket.TicketManagement.Domain.Entities;

    public interface IEventRepository: IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
