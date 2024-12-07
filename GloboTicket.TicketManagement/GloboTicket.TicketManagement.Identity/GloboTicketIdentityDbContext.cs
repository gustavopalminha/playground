namespace GloboTicket.TicketManagement.Identity
{
    using GloboTicket.TicketManagement.Identity.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GloboTicketIdentityDbContext() { }

        public GloboTicketIdentityDbContext
            (DbContextOptions<GloboTicketIdentityDbContext> options) : base(options) { }
    }
}
