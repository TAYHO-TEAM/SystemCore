using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_HopDongCommand :NS_HopDongCommandSet, IRequest<MethodResult<CreateNS_HopDongCommandResponse>>
    {
        
    }

    public class CreateNS_HopDongCommandResponse : NS_HopDongCommandResponseDTO { }
}