
namespace GloboTicket.TicketManagement.Domain.Entities
{
    using GloboTicket.TicketManagement.Domain.Common;

    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
