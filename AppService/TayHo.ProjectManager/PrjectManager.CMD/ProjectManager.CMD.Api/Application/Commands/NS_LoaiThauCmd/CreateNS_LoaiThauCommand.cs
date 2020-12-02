using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_LoaiThauCommand :NS_LoaiThauCommandSet, IRequest<MethodResult<CreateNS_LoaiThauCommandResponse>>
    {
        
    }

    public class CreateNS_LoaiThauCommandResponse : NS_LoaiThauCommandResponseDTO { }
}