using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountCommand : GroupAccountCommandSet, IRequest<MethodResult<CreateGroupAccountCommandResponse>>
    {
       
    }

    public class CreateGroupAccountCommandResponse : GroupAccountCommandResponseDTO { }
}