﻿namespace GloboTicket.TicketManagement.Application.Profiles
{
    using AutoMapper;
    using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
    using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
    using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
    using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
    using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
    using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
    using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
    using GloboTicket.TicketManagement.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

        }
    }
}
