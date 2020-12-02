using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_HopDongCommand : NS_HopDongCommandSet,IRequest<MethodResult<UpdateNS_HopDongCommandResponse>>
    {
       
    }

    public class UpdateNS_HopDongCommandResponse : NS_HopDongCommandResponseDTO
    {
    }
}