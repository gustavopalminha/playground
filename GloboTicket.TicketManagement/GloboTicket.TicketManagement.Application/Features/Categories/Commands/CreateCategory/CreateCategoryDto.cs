
namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    using System;

    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
