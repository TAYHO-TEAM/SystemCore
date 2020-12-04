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
    public class UpdateNS_NganSachCommandHandler : NS_NganSachCommandHandler,IRequestHandler<UpdateNS_NganSachCommand, MethodResult<UpdateNS_NganSachCommandResponse>>
    {
        public UpdateNS_NganSachCommandHandler(IMapper mapper, INS_NganSachRepository NS_NganSachRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NganSachRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NganSach.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NganSachCommandResponse>> Handle(UpdateNS_NganSachCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NganSachCommandResponse>();
            var existingNS_NganSach = await _NS_NganSachRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NganSach == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NganSach.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NganSach.IsActive;
            existingNS_NganSach.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NganSach.IsVisible;
            existingNS_NganSach.Status = request.Status.HasValue ? request.Status : existingNS_NganSach.Status;
            existingNS_NganSach.SetProjectId(request.ProjectId);
            existingNS_NganSach.SetHangMucId(request.HangMucId);
            existingNS_NganSach.SetGoiThauId(request.GoiThauId);
            existingNS_NganSach.SetGiaiDoanId(request.GiaiDoanId);
            existingNS_NganSach.SetDienGiai(request.DienGiai);
            existingNS_NganSach.SetGiaTri(request.GiaTri);
            existingNS_NganSach.SetisLock(request.isLock);
            existingNS_NganSach.SetUpdate(_user,0);
            _NS_NganSachRepository.Update(existingNS_NganSach);
            await _NS_NganSachRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NganSachCommandResponse>(existingNS_NganSach);
            return methodResult;
        }
    }
}