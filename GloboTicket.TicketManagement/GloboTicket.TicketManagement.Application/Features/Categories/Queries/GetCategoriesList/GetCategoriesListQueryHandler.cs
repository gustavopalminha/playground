namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    using AutoMapper;
    using GloboTicket.TicketManagement.Application.Contracts.Persistence;
    using GloboTicket.TicketManagement.Domain.Entities;
    using MediatR;

    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRespository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Category> categoryRepository
        ) { 
            _categoryRespository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRespository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryListVm>>(allCategories);
        }
    }
}
