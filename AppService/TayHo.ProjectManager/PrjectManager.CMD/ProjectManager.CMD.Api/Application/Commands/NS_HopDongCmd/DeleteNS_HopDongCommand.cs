using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_HopDongCommand : IRequest<MethodResult<DeleteNS_HopDongCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_HopDongCommandResponse
    {
        public DeleteNS_HopDongCommandResponse(List<NS_HopDongCommandResponseDTO> NS_HopDong)
        {
            _NS_HopDong = NS_HopDong;
        }

        public List<NS_HopDongCommandResponseDTO> _NS_HopDong { get; }
    }
}