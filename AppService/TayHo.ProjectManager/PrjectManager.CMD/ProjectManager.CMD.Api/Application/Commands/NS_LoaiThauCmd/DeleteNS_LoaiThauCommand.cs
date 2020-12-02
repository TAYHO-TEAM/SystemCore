using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_LoaiThauCommand : IRequest<MethodResult<DeleteNS_LoaiThauCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_LoaiThauCommandResponse
    {
        public DeleteNS_LoaiThauCommandResponse(List<NS_LoaiThauCommandResponseDTO> NS_LoaiThau)
        {
            _NS_LoaiThau = NS_LoaiThau;
        }

        public List<NS_LoaiThauCommandResponseDTO> _NS_LoaiThau { get; }
    }
}