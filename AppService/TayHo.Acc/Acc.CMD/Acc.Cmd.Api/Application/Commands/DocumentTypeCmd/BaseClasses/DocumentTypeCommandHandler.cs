using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class DocumentTypeCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IDocumentTypeRepository _DocumentTypeRepository;

        public DocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository DocumentTypeRepository)
        {
            _mapper = mapper;
            _DocumentTypeRepository = DocumentTypeRepository;
        }
    }
}