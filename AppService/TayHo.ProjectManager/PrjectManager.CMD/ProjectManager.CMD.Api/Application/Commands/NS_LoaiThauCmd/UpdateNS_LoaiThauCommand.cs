using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_LoaiThauCommand : NS_LoaiThauCommandSet,IRequest<MethodResult<UpdateNS_LoaiThauCommandResponse>>
    {
       
    }

    public class UpdateNS_LoaiThauCommandResponse : NS_LoaiThauCommandResponseDTO
    {
    }
}