﻿namespace GloboTicket.TicketManagement.Identity.Seed
{
    using GloboTicket.TicketManagement.Identity.Models;
    using Microsoft.AspNetCore.Identity;

    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "John",
                LastName = "Smith",
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Azerty&01?");
            }
        }
    }
}