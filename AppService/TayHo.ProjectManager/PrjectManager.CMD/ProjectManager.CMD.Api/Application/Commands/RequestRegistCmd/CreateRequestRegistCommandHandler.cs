using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;
using System.Linq;
using System.Collections.Generic;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.Common;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestRegistCommandHandler : RequestRegistCommandHandler, IRequestHandler<CreateRequestRegistCommand, MethodResult<CreateRequestRegistCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        public CreateRequestRegistCommandHandler(IMapper mapper, IRequestRegistRepository RequestRegistRepository, IHttpContextAccessor httpContextAccessor, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, RequestRegistRepository, httpContextAccessor)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new RequestRegist
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateRequestRegistCommandResponse>> Handle(CreateRequestRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateRequestRegistCommandResponse>();

            var parentRequestRegist = await _requestRegistRepository.SingleOrDefaultAsync(x => x.Id == request.ParentId && x.IsDelete == false).ConfigureAwait(false);
            var lastRequestRegistsRev = (await _requestRegistRepository.GetAllListAsync(x => x.ParentId == request.ParentId && x.IsDelete == false).ConfigureAwait(false)).Max(x => x.Rev);
            if (parentRequestRegist == null && (request.ParentId.HasValue && request.ParentId != 0))
            {
                methodResult.AddErrorMessage(nameof(ErrorCodeInsert.IErrN3), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.ParentId),request.ParentId)
                });
            }
            else if (!request.ParentId.HasValue || request.ParentId == 0)
            {
                request.ParentId =request.Rev= request.Level = 0;

                request.Code =(await _requestRegistRepository.IsGetTitleRequestRegistAsync((int)request.ProjectId, (int)request.WorkItemId, _user, (int)request.DocumentTypeId).ConfigureAwait(false)).Replace("-","");
            }
            else
            {
                //request.Title = !string.IsNullOrEmpty(parentRequestRegist.Title)? parentRequestRegist.Title: await _requestRegistRepository.IsGetTitleRequestRegistAsync(request.ProjectId, request.WorkItemId, _user, request.DocumentTypeId).ConfigureAwait(false);
                request.ProjectId = (int)parentRequestRegist.ProjectId;
                request.WorkItemId = (int)parentRequestRegist.WorkItemId;
                request.DocumentTypeId = (int)parentRequestRegist.DocumentTypeId;
                request.Level = (parentRequestRegist.Level.HasValue ? ((int)parentRequestRegist.Level + 1) : 0);
                request.Rev = lastRequestRegistsRev.HasValue? lastRequestRegistsRev + 1:1;
                request.Code = !string.IsNullOrEmpty(parentRequestRegist.Code) ? parentRequestRegist.Code : "0";
            }
            var newRequestRegist = new RequestRegist((int)request.PlanRegisterId,
                                                        request.Code,
                                                        request.BarCode,
                                                        request.Title,
                                                        request.Descriptions,
                                                        request.Note,
                                                        (int)request.ParentId,
                                                        request.Level,
                                                        request.NoAttachment,
                                                        (int)request.ProjectId,
                                                        (int)request.WorkItemId,
                                                        (int)request.DocumentTypeId,
                                                        request.Rev);
            newRequestRegist.SetCreate(_user);
            newRequestRegist.Status = request.Status.HasValue ? request.Status : newRequestRegist.Status;
            newRequestRegist.IsActive = request.IsActive.HasValue ? request.IsActive : newRequestRegist.IsActive;
            newRequestRegist.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newRequestRegist.IsVisible;
            await _requestRegistRepository.AddAsync(newRequestRegist).ConfigureAwait(false);
          
            await _requestRegistRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            var isRequestRegist = await _requestRegistRepository.IsCreatedRequestRegistAsync((int)newRequestRegist.DocumentTypeId, (int)newRequestRegist.CreateBy, newRequestRegist.Id).ConfigureAwait(false);
            await _mediaService.SaveFile(request.getFile(), @"D:\duan\Content\Upload", "test" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png", @"D:\duan\Content\Upload" + "\test" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            var newfileAttachment = new FilesAttachment((int)newRequestRegist.Id, QuanLyDuAnConstants.ResponseRegist_TABLENAME, "", "test", "png", "@@", "", "", @"D:\duan\Content\Upload");
            await _filesAttachmentRepository.AddAsync(newfileAttachment);
            await _filesAttachmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            //if (!isRequestRegist)
            //{
            //    methodResult.AddErrorMessage(nameof(ErrorCodeInsert.IErrN4), new[]
            //    {
            //        ErrorHelpers.GenerateErrorResult(nameof(newRequestRegist.ParentId),newRequestRegist.ParentId)
            //    });

            //}
            methodResult.Result = _mapper.Map<CreateRequestRegistCommandResponse>(newRequestRegist);
            return methodResult;
        }
    }
}