﻿namespace GloboTicket.TicketManagement.Api.Services
{
    using GloboTicket.TicketManagement.Application.Contracts;
    using System.Security.Claims;

    public class LoggedInUserService: ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string UserId
        {
            get
            {
                return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}