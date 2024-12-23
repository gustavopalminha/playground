﻿namespace GloboTicket.TicketManagement.Application.Contracts.Identity
{
    using GloboTicket.TicketManagement.Application.Models.Authentication;

    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
