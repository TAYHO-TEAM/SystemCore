using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupFunctionCommandHandler : GroupFunctionCommandHandler, IRequestHandler<CreateGroupFunctionCommand, MethodResult<CreateGroupFunctionCommandResponse>>
    {
        public CreateGroupFunctionCommandHandler(IMapper mapper, IGroupFunctionRepository GroupFunctionRepository) : base(mapper, GroupFunctionRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupFunction
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupFunctionCommandResponse>> Handle(CreateGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupFunctionCommandResponse>();
            var newGroupFunction = new GroupFunction(request.FunctionId,
                                                    request.GroupId);
            newGroupFunction.Status = request.Status.HasValue ? request.Status : newGroupFunction.Status;
            newGroupFunction.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupFunction.IsActive;
            newGroupFunction.IsVisible = request.IsActive.HasValue ? request.IsVisible : newGroupFunction.IsVisible;
            await _GroupFunctionRepository.AddAsync(newGroupFunction).ConfigureAwait(false);
            await _GroupFunctionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupFunctionCommandResponse>(newGroupFunction);
            return methodResult;
        }
    }
}