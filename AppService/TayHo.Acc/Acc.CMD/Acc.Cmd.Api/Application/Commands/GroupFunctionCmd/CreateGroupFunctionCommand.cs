using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupFunctionCommand : GroupFunctionCommandSet, IRequest<MethodResult<CreateGroupFunctionCommandResponse>>
    {
       
    }

    public class CreateGroupFunctionCommandResponse : GroupFunctionCommandResponseDTO { }
}