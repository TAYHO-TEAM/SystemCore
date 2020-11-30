using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class CategorysCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly ICategorysRepository _CategorysRepository;

        public CategorysCommandHandler(IMapper mapper, ICategorysRepository CategorysRepository)
        {
            _mapper = mapper;
            _CategorysRepository = CategorysRepository;
        }
    }
}