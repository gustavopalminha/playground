﻿namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
    using GloboTicket.TicketManagement.Application.Models.Mail;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Net;
    using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);
            _logger.LogInformation("Email sent");

            if (
                response.StatusCode == HttpStatusCode.Accepted || 
                response.StatusCode == HttpStatusCode.OK
              )
                return true;

            _logger.LogError("Email sending failed");
            
            return false;
        }
    }
}
