using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NganSachDetailCommand : NS_NganSachDetailCommandSet,IRequest<MethodResult<UpdateNS_NganSachDetailCommandResponse>>
    {
       
    }

    public class UpdateNS_NganSachDetailCommandResponse : NS_NganSachDetailCommandResponseDTO
    {
    }
}