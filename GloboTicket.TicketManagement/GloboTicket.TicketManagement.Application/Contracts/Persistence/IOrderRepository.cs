﻿namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    using GloboTicket.TicketManagement.Domain.Entities;

    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);

    }
}
