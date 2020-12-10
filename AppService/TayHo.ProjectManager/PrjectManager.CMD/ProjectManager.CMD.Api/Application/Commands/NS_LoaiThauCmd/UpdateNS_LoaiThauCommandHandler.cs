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
    public class UpdateNS_LoaiThauCommandHandler : NS_LoaiThauCommandHandler,IRequestHandler<UpdateNS_LoaiThauCommand, MethodResult<UpdateNS_LoaiThauCommandResponse>>
    {
        public UpdateNS_LoaiThauCommandHandler(IMapper mapper, INS_LoaiThauRepository NS_LoaiThauRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_LoaiThauRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_LoaiThau.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_LoaiThauCommandResponse>> Handle(UpdateNS_LoaiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_LoaiThauCommandResponse>();
            var existingNS_LoaiThau = await _NS_LoaiThauRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_LoaiThau == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (existingNS_LoaiThau.CreateBy != _user)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr02), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_LoaiThau.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_LoaiThau.IsActive;
            existingNS_LoaiThau.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_LoaiThau.IsVisible;
            existingNS_LoaiThau.Status = request.Status.HasValue ? request.Status : existingNS_LoaiThau.Status;
            existingNS_LoaiThau.SetParentId(request.ParentId);
            existingNS_LoaiThau.SetTenLoaiThau(request.TenLoaiThau);
            existingNS_LoaiThau.SetDienGiai(request.DienGiai);
            existingNS_LoaiThau.SetProjectId(request.ProjectId);
            existingNS_LoaiThau.SetUpdate(_user,0);
            _NS_LoaiThauRepository.Update(existingNS_LoaiThau);
            await _NS_LoaiThauRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_LoaiThauCommandResponse>(existingNS_LoaiThau);
            return methodResult;
        }
    }
}