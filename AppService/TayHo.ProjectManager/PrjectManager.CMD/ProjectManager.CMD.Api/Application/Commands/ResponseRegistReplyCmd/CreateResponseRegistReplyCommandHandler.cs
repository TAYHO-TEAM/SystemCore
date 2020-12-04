﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;


namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateResponseRegistReplyCommandHandler : ResponseRegistReplyCommandHandler, IRequestHandler<CreateResponseRegistReplyCommand, MethodResult<CreateResponseRegistReplyCommandResponse>>
    {
        public CreateResponseRegistReplyCommandHandler(IMapper mapper, IResponseRegistReplyRepository ResponseRegistReplyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ResponseRegistReplyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new ResponseRegistReply
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateResponseRegistReplyCommandResponse>> Handle(CreateResponseRegistReplyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateResponseRegistReplyCommandResponse>();
            var newResponseRegistReply = new ResponseRegistReply(request.Title,
                                                                    request.Description,
                                                                    request.ReplyAccountId,
                                                                    request.ResponseRegitId,
                                                                    request.NoAttachment);
            newResponseRegistReply.SetCreate(_user);
            newResponseRegistReply.Status = request.Status.HasValue ? request.Status : newResponseRegistReply.Status;
            newResponseRegistReply.IsActive = request.IsActive.HasValue ? request.IsActive : newResponseRegistReply.IsActive;
            newResponseRegistReply.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newResponseRegistReply.IsVisible;
            await _ResponseRegistReplyRepository.AddAsync(newResponseRegistReply).ConfigureAwait(false);
            await _ResponseRegistReplyRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateResponseRegistReplyCommandResponse>(newResponseRegistReply);
            return methodResult;
        }
    }
}