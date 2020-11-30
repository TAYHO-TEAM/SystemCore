using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class RequestDetailCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IRequestDetailRepository _RequestDetailRepository;

        public RequestDetailCommandHandler(IMapper mapper, IRequestDetailRepository RequestDetailRepository)
        {
            _mapper = mapper;
            _RequestDetailRepository = RequestDetailRepository;
        }
    }
}