using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class RequestsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IRequestsRepository _RequestsRepository;

        public RequestsCommandHandler(IMapper mapper, IRequestsRepository RequestsRepository)
        {
            _mapper = mapper;
            _RequestsRepository = RequestsRepository;
        }
    }
}