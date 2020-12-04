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
    public class CreateNS_LoaiThauCommandHandler : NS_LoaiThauCommandHandler, IRequestHandler<CreateNS_LoaiThauCommand, MethodResult<CreateNS_LoaiThauCommandResponse>>
    {
        public CreateNS_LoaiThauCommandHandler(IMapper mapper, INS_LoaiThauRepository NS_LoaiThauRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_LoaiThauRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_LoaiThau
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_LoaiThauCommandResponse>> Handle(CreateNS_LoaiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_LoaiThauCommandResponse>();
            var newNS_LoaiThau = new NS_LoaiThau(request.ParentId,
                request.TenGoiThau,
                request.DienGiai,
                request.ProjectId);
            newNS_LoaiThau.SetCreate(_user);
            newNS_LoaiThau.Status = request.Status.HasValue ? request.Status : newNS_LoaiThau.Status;
            newNS_LoaiThau.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_LoaiThau.IsActive;
            newNS_LoaiThau.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_LoaiThau.IsVisible;
            await _NS_LoaiThauRepository.AddAsync(newNS_LoaiThau).ConfigureAwait(false);
            await _NS_LoaiThauRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_LoaiThauCommandResponse>(newNS_LoaiThau);
            return methodResult;
        }
    }
}