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
    public class CreateNS_NganSachDetailCommandHandler : NS_NganSachDetailCommandHandler, IRequestHandler<CreateNS_NganSachDetailCommand, MethodResult<CreateNS_NganSachDetailCommandResponse>>
    {
        public CreateNS_NganSachDetailCommandHandler(IMapper mapper, INS_NganSachDetailRepository NS_NganSachDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NganSachDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NganSachDetail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NganSachDetailCommandResponse>> Handle(CreateNS_NganSachDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NganSachDetailCommandResponse>();
            var newNS_NganSachDetail = new NS_NganSachDetail(request.NganSachId,
                request.CongViec,
                request.GiaTri,
                request.NgayCapNhat,
                request.DienGiai,
                request.isLock);
            newNS_NganSachDetail.SetCreate(_user);
            newNS_NganSachDetail.Status = request.Status.HasValue ? request.Status : newNS_NganSachDetail.Status;
            newNS_NganSachDetail.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NganSachDetail.IsActive;
            newNS_NganSachDetail.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_NganSachDetail.IsVisible;
            await _NS_NganSachDetailRepository.AddAsync(newNS_NganSachDetail).ConfigureAwait(false);
            await _NS_NganSachDetailRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NganSachDetailCommandResponse>(newNS_NganSachDetail);
            return methodResult;
        }
    }
}