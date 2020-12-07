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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestRegistCommandHandler : RequestRegistCommandHandler, IRequestHandler<CreateRequestRegistCommand, MethodResult<CreateRequestRegistCommandResponse>>
    {
        public CreateRequestRegistCommandHandler(IMapper mapper, IRequestRegistRepository RequestRegistRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestRegistRepository,httpContextAccessor)
        {
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
    
            var parentRequestRegist = await _requestRegistRepository.SingleOrDefaultAsync(x => x.Id == request.ParentId && x.IsDelete == false ).ConfigureAwait(false);
            var lastRequestRegistsRev = (await _requestRegistRepository.GetAllListAsync(x => x.ParentId == request.ParentId && x.IsDelete == false).ConfigureAwait(false)).Max(x=>x.Rev);
            if (parentRequestRegist == null && (request.ParentId.HasValue || request.ParentId != 0))
            {
                methodResult.AddErrorMessage(nameof(ErrorCodeInsert.IErrN3), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.ParentId),request.ParentId)
                });
            }
            else if (!request.ParentId.HasValue || request.ParentId == 0)
            {
                request.Rev = 0;
                request.Code = parentRequestRegist.Code;
                request.Title = parentRequestRegist.Title;
            }
            else
            {
                request.Title = await  _requestRegistRepository.IsGetTitleRequestRegistAsync(request.ProjectId,request.WorkItemId,_user,request.DocumentTypeId).ConfigureAwait(false);
                request.Level = (parentRequestRegist.Level.HasValue ? ((int)parentRequestRegist.Level + 1) : 0);
                request.Rev = lastRequestRegistsRev?? + 1;
            }
            var newRequestRegist = new RequestRegist(request.Code,
                                                        request.BarCode,
                                                        request.Title,
                                                        request.Descriptions,
                                                        request.ParentId,
                                                        request.Level,
                                                        request.NoAttachment,
                                                        request.ProjectId,
                                                        request.WorkItemId,
                                                        request.DocumentTypeId,
                                                        request.Rev);
            newRequestRegist.SetCreate(_user);
            newRequestRegist.Status = request.Status.HasValue ? request.Status : newRequestRegist.Status;
            newRequestRegist.IsActive = request.IsActive.HasValue ? request.IsActive : newRequestRegist.IsActive;
            newRequestRegist.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newRequestRegist.IsVisible;
            await _requestRegistRepository.AddAsync(newRequestRegist).ConfigureAwait(false);
            await _requestRegistRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateRequestRegistCommandResponse>(newRequestRegist);
            return methodResult;
        }
    }
}