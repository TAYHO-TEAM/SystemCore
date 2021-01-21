using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyAccountCommand : NotifyAccountCommandSet, IRequest<MethodResult<CreateNotifyAccountCommandResponse>>
    {
       
    }

    public class CreateNotifyAccountCommandResponse : NotifyAccountCommandResponseDTO { }
}
