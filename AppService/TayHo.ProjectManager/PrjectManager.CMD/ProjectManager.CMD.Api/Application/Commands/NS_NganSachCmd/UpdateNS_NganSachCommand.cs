using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NganSachCommand : NS_NganSachCommandSet,IRequest<MethodResult<UpdateNS_NganSachCommandResponse>>
    {
       
    }

    public class UpdateNS_NganSachCommandResponse : NS_NganSachCommandResponseDTO
    {
    }
}