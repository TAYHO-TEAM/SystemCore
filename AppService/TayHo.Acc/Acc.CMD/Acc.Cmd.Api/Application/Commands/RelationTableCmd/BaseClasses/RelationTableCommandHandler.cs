using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class RelationTableCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IRelationTableRepository _RelationTableRepository;

        public RelationTableCommandHandler(IMapper mapper, IRelationTableRepository RelationTableRepository)
        {
            _mapper = mapper;
            _RelationTableRepository = RelationTableRepository;
        }
    }
}