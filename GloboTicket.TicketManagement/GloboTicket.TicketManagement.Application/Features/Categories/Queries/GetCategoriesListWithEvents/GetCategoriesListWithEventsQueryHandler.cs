
namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    using AutoMapper;
    using GloboTicket.TicketManagement.Application.Contracts.Persistence;
    using MediatR;

    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
    {
        public readonly IMapper _mapper;
        public readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithEventsQueryHandler(
            IMapper mapper,
            ICategoryRepository categoryRepository
        ){
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(list);

        }
    }
}
