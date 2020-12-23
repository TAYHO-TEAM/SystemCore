using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedAccountCommand :DocumentReleasedAccountCommandSet, IRequest<MethodResult<CreateDocumentReleasedAccountCommandResponse>>
    {
        
    }

    public class CreateDocumentReleasedAccountCommandResponse : DocumentReleasedAccountCommandResponseDTO { }
}