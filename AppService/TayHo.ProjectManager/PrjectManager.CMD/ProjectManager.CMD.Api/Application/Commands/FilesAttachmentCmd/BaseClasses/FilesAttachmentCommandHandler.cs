using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class FilesAttachmentCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IFilesAttachmentRepository _FilesAttachmentRepository;

        public FilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository)
        {
            _mapper = mapper;
            _FilesAttachmentRepository = FilesAttachmentRepository;
        }
    }
}