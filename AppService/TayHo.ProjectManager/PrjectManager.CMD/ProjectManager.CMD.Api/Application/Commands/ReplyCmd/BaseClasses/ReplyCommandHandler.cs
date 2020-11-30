using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ReplyCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IReplyRepository _ReplyRepository;

        public ReplyCommandHandler(IMapper mapper, IReplyRepository ReplyRepository)
        {
            _mapper = mapper;
            _ReplyRepository = ReplyRepository;
        }
    }
}