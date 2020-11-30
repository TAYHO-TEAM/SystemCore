using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
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