using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NganSachCommand : IRequest<MethodResult<DeleteNS_NganSachCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NganSachCommandResponse
    {
        public DeleteNS_NganSachCommandResponse(List<NS_NganSachCommandResponseDTO> NS_NganSach)
        {
            _NS_NganSach = NS_NganSach;
        }

        public List<NS_NganSachCommandResponseDTO> _NS_NganSach { get; }
    }
}