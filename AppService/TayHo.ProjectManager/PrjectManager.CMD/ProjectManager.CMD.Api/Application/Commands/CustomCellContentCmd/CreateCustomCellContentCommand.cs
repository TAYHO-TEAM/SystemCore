using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomCellContentCommand :CustomCellContentCommandSet, IRequest<MethodResult<CreateCustomCellContentCommandResponse>>
    {
        
    }

    public class CreateCustomCellContentCommandResponse : CustomCellContentCommandResponseDTO { }
}