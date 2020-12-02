using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NganSachDetailCommand : IRequest<MethodResult<DeleteNS_NganSachDetailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NganSachDetailCommandResponse
    {
        public DeleteNS_NganSachDetailCommandResponse(List<NS_NganSachDetailCommandResponseDTO> NS_NganSachDetail)
        {
            _NS_NganSachDetail = NS_NganSachDetail;
        }

        public List<NS_NganSachDetailCommandResponseDTO> _NS_NganSachDetail { get; }
    }
}