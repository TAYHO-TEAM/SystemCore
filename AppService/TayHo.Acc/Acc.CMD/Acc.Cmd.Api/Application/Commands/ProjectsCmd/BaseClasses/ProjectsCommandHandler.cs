using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class ProjectsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IProjectsRepository _ProjectsRepository;

        public ProjectsCommandHandler(IMapper mapper, IProjectsRepository ProjectsRepository)
        {
            _mapper = mapper;
            _ProjectsRepository = ProjectsRepository;
        }
    }
}