using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.IService;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFilesAttachmentCommandHandler : FilesAttachmentCommandHandler, IRequestHandler<CreateFilesAttachmentCommand, MethodResult<CreateFilesAttachmentCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        public CreateFilesAttachmentCommandHandler(IMapper mapper, IFilesAttachmentRepository FilesAttachmentRepository,IHttpContextAccessor httpContextAccessor, IMediaService mediaService) : base(mapper, FilesAttachmentRepository,httpContextAccessor)
        {
            _mediaService= mediaService;
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
                                                        "",
                                                        request.Type,
                                                        request.Direct);
            newFilesAttachment.SetCreate(_user);
            newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
            newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : newFilesAttachment.IsActive;
            newFilesAttachment.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newFilesAttachment.IsVisible;
            var result = await _mediaService.SaveFile(request.getFile(), request.OwnerByTable, request.FileName);
            newFilesAttachment.SetFileName(result.Item1);
            newFilesAttachment.SetHost(result.Item3);
            newFilesAttachment.SetUrl(result.Item3 + newFilesAttachment.FileName);
            newFilesAttachment.SetDirect(result.Item2);
            await _FilesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
            await _FilesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            
            methodResult.Result = _mapper.Map<CreateFilesAttachmentCommandResponse>(newFilesAttachment);
            return methodResult;
        }
    }
}