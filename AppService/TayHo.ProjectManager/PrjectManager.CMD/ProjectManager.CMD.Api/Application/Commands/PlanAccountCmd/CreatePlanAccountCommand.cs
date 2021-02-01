using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanAccountCommand : PlanAccountCommandSet, IRequest<MethodResult<CreatePlanAccountCommandResponse>>
    {
       
    }

    public class CreatePlanAccountCommandResponse : PlanAccountCommandResponseDTO { }
}
