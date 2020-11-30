using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFilesAttachmentCommandHandler : FilesAttachmentCommandHandler, IRequestHandler<CreateFilesAttachmentCommand, MethodResult<CreateFilesAttachmentCommandResponse>>
    {
        public CreateFilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository) : base(mapper, FilesAttachmentRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new FilesAttachment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFilesAttachmentCommandResponse>> Handle(CreateFilesAttachmentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateFilesAttachmentCommandResponse>();
            var newFilesAttachment = new FilesAttachment(request.OwnerById,
                                                        request.OwnerByTable,
                                                        request.Code,
                                                        request.FileName,
                                                        request.Tail,
                                                        request.Url,
                                                        request.Host,
                                                        request.Type,
                                                        request.Direct);
            newFilesAttachment.SetCreateAccount(0);
            newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
            newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : newFilesAttachment.IsActive;
            newFilesAttachment.IsVisible = request.IsActive.HasValue ? request.IsVisible : newFilesAttachment.IsVisible;
            await _FilesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
            await _FilesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateFilesAttachmentCommandResponse>(newFilesAttachment);
            return methodResult;
        }
    }
}