using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NganSachDetailCommand :NS_NganSachDetailCommandSet, IRequest<MethodResult<CreateNS_NganSachDetailCommandResponse>>
    {
        
    }

    public class CreateNS_NganSachDetailCommandResponse : NS_NganSachDetailCommandResponseDTO { }
}