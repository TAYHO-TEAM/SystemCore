using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_HopDongCommandHandler : NS_HopDongCommandHandler,IRequestHandler<UpdateNS_HopDongCommand, MethodResult<UpdateNS_HopDongCommandResponse>>
    {
        public UpdateNS_HopDongCommandHandler(IMapper mapper, INS_HopDongRepository NS_HopDongRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HopDongRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_HopDong.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_HopDongCommandResponse>> Handle(UpdateNS_HopDongCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_HopDongCommandResponse>();
            var existingNS_HopDong = await _NS_HopDongRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HopDong == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (existingNS_HopDong.CreateBy != _user)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr02), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_HopDong.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_HopDong.IsActive;
            existingNS_HopDong.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_HopDong.IsVisible;
            existingNS_HopDong.Status = request.Status.HasValue ? request.Status : existingNS_HopDong.Status;
            existingNS_HopDong.SetParentId(request.ParentId);
            existingNS_HopDong.SetSoHopDong(request.SoHopDong);
            existingNS_HopDong.SetContractorInfoId(request.ContractorInfoId);
            existingNS_HopDong.SetGiaTri(request.GiaTri);
            existingNS_HopDong.SetNgayKy(request.NgayKy);
            existingNS_HopDong.SetDienGiai(request.DienGiai);
            existingNS_HopDong.SetUpdate(_user,0);
            _NS_HopDongRepository.Update(existingNS_HopDong);
            await _NS_HopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_HopDongCommandResponse>(existingNS_HopDong);
            return methodResult;
        }
    }
}