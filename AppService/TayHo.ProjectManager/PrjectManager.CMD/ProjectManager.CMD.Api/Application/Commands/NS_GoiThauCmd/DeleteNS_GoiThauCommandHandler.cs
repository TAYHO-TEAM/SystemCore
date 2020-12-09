using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NganSachCommandHandler : NS_NganSachCommandHandler, IRequestHandler<DeleteNS_NganSachCommand, MethodResult<DeleteNS_NganSachCommandResponse>>
    {
        public DeleteNS_NganSachCommandHandler(IMapper mapper, INS_NganSachRepository NS_NganSachRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NganSachRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NganSach.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NganSachCommandResponse>> Handle(DeleteNS_NganSachCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NganSachCommandResponse>();
            var existingNS_NganSach = await _NS_NganSachRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NganSach == null || !existingNS_NganSach.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_NganSach)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_NganSachRepository.UpdateRange(existingNS_NganSach);
            await _NS_NganSachRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NganSachResponseDTOs = _mapper.Map<List<NS_NganSachCommandResponseDTO>>(existingNS_NganSach);
            methodResult.Result = new DeleteNS_NganSachCommandResponse(NS_NganSachResponseDTOs);
            return methodResult;
        }
    }
}