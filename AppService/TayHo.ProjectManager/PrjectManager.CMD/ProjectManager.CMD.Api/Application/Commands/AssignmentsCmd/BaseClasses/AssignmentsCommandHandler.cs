using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class AssignmentsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IAssignmentsRepository _AssignmentsRepository;

        public AssignmentsCommandHandler(IMapper mapper, IAssignmentsRepository AssignmentsRepository)
        {
            _mapper = mapper;
            _AssignmentsRepository = AssignmentsRepository;
        }
    }
}