using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupFunctionCommand : IRequest<MethodResult<DeleteGroupFunctionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupFunctionCommandResponse
    {
        public DeleteGroupFunctionCommandResponse(List<GroupFunctionCommandResponseDTO> GroupFunction)
        {
            _GroupFunction = GroupFunction;
        }

        public List<GroupFunctionCommandResponseDTO> _GroupFunction { get; }
    }
}