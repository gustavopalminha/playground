namespace GloboTicket.TicketManagement.App.Contracts
{
    using GloboTicket.TicketManagement.App.Services;
    using GloboTicket.TicketManagement.App.Services.Base;
    using GloboTicket.TicketManagement.App.ViewModels;

    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
