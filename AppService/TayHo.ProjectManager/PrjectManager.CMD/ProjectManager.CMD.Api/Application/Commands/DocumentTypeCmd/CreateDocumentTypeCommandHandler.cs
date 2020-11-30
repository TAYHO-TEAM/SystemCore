﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentTypeCommandHandler : DocumentTypeCommandHandler, IRequestHandler<CreateDocumentTypeCommand, MethodResult<CreateDocumentTypeCommandResponse>>
    {
        public CreateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository DocumentTypeRepository) : base(mapper, DocumentTypeRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new DocumentType
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentTypeCommandResponse>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentTypeCommandResponse>();
            var newDocumentType = new DocumentType(request.Code, request.Title, request.Descriptions);
            newDocumentType.SetCreateAccount(0);
            newDocumentType.Status = request.Status.HasValue ? request.Status : newDocumentType.Status;
            newDocumentType.IsActive = request.IsActive.HasValue ? request.IsActive : newDocumentType.IsActive;
            newDocumentType.IsVisible = request.IsActive.HasValue ? request.IsVisible : newDocumentType.IsVisible;
            await _DocumentTypeRepository.AddAsync(newDocumentType).ConfigureAwait(false);
            await _DocumentTypeRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateDocumentTypeCommandResponse>(newDocumentType);
            return methodResult;
        }
    }
}