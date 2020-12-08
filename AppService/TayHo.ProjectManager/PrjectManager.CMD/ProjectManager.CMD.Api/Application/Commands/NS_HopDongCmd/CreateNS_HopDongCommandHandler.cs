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
    public class CreateNS_HopDongCommandHandler : NS_HopDongCommandHandler, IRequestHandler<CreateNS_HopDongCommand, MethodResult<CreateNS_HopDongCommandResponse>>
    {
        public CreateNS_HopDongCommandHandler(IMapper mapper, INS_HopDongRepository NS_HopDongRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HopDongRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_HopDong
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_HopDongCommandResponse>> Handle(CreateNS_HopDongCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_HopDongCommandResponse>();
            var newNS_HopDong = new NS_HopDong(request.ParentId,
                request.SoHopDong,
                request.ContractorInfoId,
                request.LoaiThauId,
                request.GiaTri,
                request.NgayKy,
                request.DienGiai);
            newNS_HopDong.SetCreate(_user);
            newNS_HopDong.Status = request.Status.HasValue ? request.Status : newNS_HopDong.Status;
            newNS_HopDong.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_HopDong.IsActive;
            newNS_HopDong.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_HopDong.IsVisible;
            await _NS_HopDongRepository.AddAsync(newNS_HopDong).ConfigureAwait(false);
            await _NS_HopDongRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_HopDongCommandResponse>(newNS_HopDong);
            return methodResult;
        }
    }
}