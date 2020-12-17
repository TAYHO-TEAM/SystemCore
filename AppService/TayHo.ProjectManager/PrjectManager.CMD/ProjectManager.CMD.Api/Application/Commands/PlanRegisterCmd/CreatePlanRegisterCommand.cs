using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanRegisterCommand :PlanRegisterCommandSet, IRequest<MethodResult<CreatePlanRegisterCommandResponse>>
    {
        
    }

    public class CreatePlanRegisterCommandResponse : PlanRegisterCommandResponseDTO { }
}