using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NganSachCommand :NS_NganSachCommandSet, IRequest<MethodResult<CreateNS_NganSachCommandResponse>>
    {
        
    }

    public class CreateNS_NganSachCommandResponse : NS_NganSachCommandResponseDTO { }
}