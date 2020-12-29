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
    public class CreateDocumentReleasedCommandHandler : DocumentReleasedCommandHandler, IRequestHandler<CreateDocumentReleasedCommand, MethodResult<CreateDocumentReleasedCommandResponse>>
    {
        public CreateDocumentReleasedCommandHandler(IMapper mapper, IDocumentReleasedRepository DocumentReleasedRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, DocumentReleasedRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new DocumentReleased
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedCommandResponse>> Handle(CreateDocumentReleasedCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentReleasedCommandResponse>();
            var newDocumentReleased = new DocumentReleased(request.Title,
                                                            request.Description,
                                                            request.DocumentTypeId,
                                                            request.ProjectId,
                                                            request.WorkItemId,
                                                            request.TagWorkItem,
                                                            request.NoAttachment);
            newDocumentReleased.SetCreate(_user);
            newDocumentReleased.Status = request.Status.HasValue ? request.Status : newDocumentReleased.Status;
            newDocumentReleased.IsActive = request.IsActive.HasValue ? request.IsActive : newDocumentReleased.IsActive;
            newDocumentReleased.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newDocumentReleased.IsVisible;

            await _DocumentReleasedRepository.AddAsync(newDocumentReleased).ConfigureAwait(false);
            await _DocumentReleasedRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            await _DocumentReleasedRepository.IsCreatedDocumentReleasedAsync((int)newDocumentReleased.DocumentTypeId, _user, newDocumentReleased.Id);

            methodResult.Result = _mapper.Map<CreateDocumentReleasedCommandResponse>(newDocumentReleased);
            return methodResult;
        }
    }
}