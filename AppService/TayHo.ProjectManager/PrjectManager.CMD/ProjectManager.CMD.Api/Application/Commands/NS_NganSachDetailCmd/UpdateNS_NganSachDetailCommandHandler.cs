using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NganSachDetailCommandHandler : NS_NganSachDetailCommandHandler,IRequestHandler<UpdateNS_NganSachDetailCommand, MethodResult<UpdateNS_NganSachDetailCommandResponse>>
    {
        public UpdateNS_NganSachDetailCommandHandler(IMapper mapper, INS_NganSachDetailRepository NS_NganSachDetailRepository) : base(mapper, NS_NganSachDetailRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NganSachDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NganSachDetailCommandResponse>> Handle(UpdateNS_NganSachDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NganSachDetailCommandResponse>();
            var existingNS_NganSachDetail = await _NS_NganSachDetailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NganSachDetail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NganSachDetail.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NganSachDetail.IsActive;
            existingNS_NganSachDetail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NganSachDetail.IsVisible;
            existingNS_NganSachDetail.Status = request.Status.HasValue ? request.Status : existingNS_NganSachDetail.Status;
            existingNS_NganSachDetail.SetNganSachId(request.NganSachId);
            existingNS_NganSachDetail.SetCongViec(request.CongViec);
            existingNS_NganSachDetail.SetGiaTri(request.GiaTri);
            existingNS_NganSachDetail.SetNgayCapNhat(request.NgayCapNhat);
            existingNS_NganSachDetail.SetDienGiai(request.DienGiai);
            existingNS_NganSachDetail.SetisLock(request.isLock);
            existingNS_NganSachDetail.SetUpdate(0,0);
            _NS_NganSachDetailRepository.Update(existingNS_NganSachDetail);
            await _NS_NganSachDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NganSachDetailCommandResponse>(existingNS_NganSachDetail);
            return methodResult;
        }
    }
}