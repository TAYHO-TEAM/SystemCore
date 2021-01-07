using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateDocumentReleasedAccountCommandHandler : DocumentReleasedAccountCommandHandler, IRequestHandler<CreateDocumentReleasedAccountCommand, MethodResult<CreateDocumentReleasedAccountCommandResponse>>
    {
        private readonly IGroupAccountRepository _groupAccount;
        IDocumentReleasedRepository _documentReleasedRepository;
        public CreateDocumentReleasedAccountCommandHandler(IMapper mapper, IDocumentReleasedAccountRepository DocumentReleasedAccountRepository,IHttpContextAccessor httpContextAccessor, IGroupAccountRepository GroupAccount, IDocumentReleasedRepository DocumentReleasedRepository) : base(mapper, DocumentReleasedAccountRepository,httpContextAccessor)
        {
            _groupAccount = GroupAccount;
            _documentReleasedRepository = DocumentReleasedRepository;
        }

        /// <summary>
        /// Handle for creating a new DocumentReleasedAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateDocumentReleasedAccountCommandResponse>> Handle(CreateDocumentReleasedAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateDocumentReleasedAccountCommandResponse>();
            List<DocumentReleasedAccount> newDocumentReleasedAccounts = new List<DocumentReleasedAccount>();
            var existingGroupAccounts = await _groupAccount.GetAllListAsync(x => x.GroupId == request.GroupId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false);
            if(request.GroupId.HasValue && existingGroupAccounts.Count>0)
            {
                foreach (var groupAccount in existingGroupAccounts)
                {
                    if (!await _DocumentReleasedAccountRepository.AnyAsync(x => x.AccountId == groupAccount.AccountId && x.DocumentReleasedId == request.DocumentReleasedId && (x.IsDelete == false || !x.IsDelete.HasValue)).ConfigureAwait(false))
                    {
                        var newDocumentReleasedAccount = new DocumentReleasedAccount(groupAccount.AccountId,
                                                                               request.DocumentReleasedId,
                                                                               request.GroupId);
                        newDocumentReleasedAccount.SetCreate(_user);
                        newDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status :0;
                        newDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                        newDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                        newDocumentReleasedAccounts.Add(newDocumentReleasedAccount);
                    }
                }
            } 
            else if(request.AccountId >0 )
            {
                var newDocumentReleasedAccount = new DocumentReleasedAccount(request.AccountId,
                                                                             request.DocumentReleasedId,
                                                                             request.GroupId);
                newDocumentReleasedAccount.SetCreate(_user);
                newDocumentReleasedAccount.Status = request.Status.HasValue ? request.Status : 0 ;
                newDocumentReleasedAccount.IsActive = request.IsActive.HasValue ? request.IsActive :true;
                newDocumentReleasedAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible :true;
                newDocumentReleasedAccounts.Add(newDocumentReleasedAccount);
            }    
            await _DocumentReleasedAccountRepository.AddRangeAsync(newDocumentReleasedAccounts).ConfigureAwait(false);
            await _DocumentReleasedAccountRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            await _documentReleasedRepository.DocumentReleasedProcessAsync();
            var DocumentReleasedAccountResponseDTOs = _mapper.Map<List<DocumentReleasedAccountCommandResponseDTO>>(newDocumentReleasedAccounts);
            methodResult.Result = new CreateDocumentReleasedAccountCommandResponse(DocumentReleasedAccountResponseDTOs);
            return methodResult;
        }
    }
}