using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;


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
            await _RequestRegistRepository.AddAsync(newRequestRegist).ConfigureAwait(false);
            await _RequestRegistRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateRequestRegistCommandResponse>(newRequestRegist);
            return methodResult;
        }
    }
}