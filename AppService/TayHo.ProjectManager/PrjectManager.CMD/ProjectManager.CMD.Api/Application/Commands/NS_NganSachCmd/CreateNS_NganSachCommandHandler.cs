using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NganSachCommandHandler : NS_NganSachCommandHandler, IRequestHandler<CreateNS_NganSachCommand, MethodResult<CreateNS_NganSachCommandResponse>>
    {
        public CreateNS_NganSachCommandHandler(IMapper mapper, INS_NganSachRepository NS_NganSachRepository) : base(mapper, NS_NganSachRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NganSach
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NganSachCommandResponse>> Handle(CreateNS_NganSachCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NganSachCommandResponse>();
            var newNS_NganSach = new NS_NganSach(
                request.ProjectId,
                request.HangMucId,
                request.GoiThauId,
                request.GiaiDoanId,
                request.DienGiai,
                request.GiaTri,
                request.isLock);
            newNS_NganSach.SetCreateAccount(0);
            newNS_NganSach.Status = request.Status.HasValue ? request.Status : newNS_NganSach.Status;
            newNS_NganSach.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NganSach.IsActive;
            newNS_NganSach.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_NganSach.IsVisible;
            await _NS_NganSachRepository.AddAsync(newNS_NganSach).ConfigureAwait(false);
            await _NS_NganSachRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NganSachCommandResponse>(newNS_NganSach);
            return methodResult;
        }
    }
}