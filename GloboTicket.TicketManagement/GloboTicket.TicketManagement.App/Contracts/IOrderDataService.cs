namespace GloboTicket.TicketManagement.App.Contracts
{
    using GloboTicket.TicketManagement.App.ViewModels;

    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
