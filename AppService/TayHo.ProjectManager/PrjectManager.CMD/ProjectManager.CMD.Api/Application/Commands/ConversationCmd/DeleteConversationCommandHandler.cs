using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteConversationCommandHandler : ConversationCommandHandler, IRequestHandler<DeleteConversationCommand, MethodResult<DeleteConversationCommandResponse>>
    {
        public DeleteConversationCommandHandler(IMapper mapper, IConversationRepository ConversationRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ConversationRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Conversation.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteConversationCommandResponse>> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteConversationCommandResponse>();
            var existingConversations = await _conversationRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingConversations == null || !existingConversations.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingConversation in existingConversations)
            {
                existingConversation.UpdateDate = now;
                existingConversation.UpdateDateUTC = utc;
                existingConversation.IsDelete = true;
                existingConversation.SetUpdate(_user, null);
            }
            _conversationRepository.UpdateRange(existingConversations);
            await _conversationRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ConversationResponseDTOs = _mapper.Map<List<ConversationCommandResponseDTO>>(existingConversations);
            methodResult.Result = new DeleteConversationCommandResponse(ConversationResponseDTOs);
            return methodResult;
        }
    }
}
