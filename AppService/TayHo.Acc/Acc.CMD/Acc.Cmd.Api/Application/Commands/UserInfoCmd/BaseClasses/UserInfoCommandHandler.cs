using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UserInfoCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IUserInfoRepository _UserInfoRepository;

        public UserInfoCommandHandler(IMapper mapper, IUserInfoRepository UserInfoRepository)
        {
            _mapper = mapper;
            _UserInfoRepository = UserInfoRepository;
        }
    }
}