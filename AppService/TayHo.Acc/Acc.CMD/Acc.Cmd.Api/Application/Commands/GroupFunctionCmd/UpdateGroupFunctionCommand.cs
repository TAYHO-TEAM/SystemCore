using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupFunctionCommand : GroupFunctionCommandSet,IRequest<MethodResult<UpdateGroupFunctionCommandResponse>>
    {
       
    }

    public class UpdateGroupFunctionCommandResponse : GroupFunctionCommandResponseDTO
    {
    }
}