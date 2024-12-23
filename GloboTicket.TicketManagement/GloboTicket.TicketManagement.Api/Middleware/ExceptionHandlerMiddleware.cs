﻿namespace GloboTicket.TicketManagement.Api.Middleware
{
    using GloboTicket.TicketManagement.Application.Exceptions;
    using System.Net;
    using System.Text.Json;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke (HttpContext context) {

            try
            {
                await _next(context);
            }

            catch (Exception e) {
                await ConvertExeption(context, e);
            }
        }

        private Task ConvertExeption(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch(exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;

                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;

                case NotFiniteNumberException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new {error = exception.Message});
            }

            return context.Response.WriteAsync(result);

        }
    }
}
