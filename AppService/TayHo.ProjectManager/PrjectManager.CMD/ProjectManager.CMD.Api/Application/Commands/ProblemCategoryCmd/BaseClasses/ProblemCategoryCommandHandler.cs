using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ProblemCategoryCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IProblemCategoryRepository _ProblemCategoryRepository;

        public ProblemCategoryCommandHandler(IMapper mapper, IProblemCategoryRepository ProblemCategoryRepository)
        {
            _mapper = mapper;
            _ProblemCategoryRepository = ProblemCategoryRepository;
        }
    }
}