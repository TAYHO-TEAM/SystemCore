﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_GiaiDoanCommandHandler : NS_GiaiDoanCommandHandler, IRequestHandler<CreateNS_GiaiDoanCommand, MethodResult<CreateNS_GiaiDoanCommandResponse>>
    {
        public CreateNS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository) : base(mapper, NS_GiaiDoanRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_GiaiDoan
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_GiaiDoanCommandResponse>> Handle(CreateNS_GiaiDoanCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_GiaiDoanCommandResponse>();
            var newNS_GiaiDoan = new NS_GiaiDoan(request.TenGiaiDoan,request.DienGiai);
            newNS_GiaiDoan.SetCreateAccount(0);
            newNS_GiaiDoan.Status = request.Status.HasValue ? request.Status : newNS_GiaiDoan.Status;
            newNS_GiaiDoan.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_GiaiDoan.IsActive;
            newNS_GiaiDoan.IsVisible = request.IsActive.HasValue ? request.IsVisible : newNS_GiaiDoan.IsVisible;
            await _NS_GiaiDoanRepository.AddAsync(newNS_GiaiDoan).ConfigureAwait(false);
            await _NS_GiaiDoanRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_GiaiDoanCommandResponse>(newNS_GiaiDoan);
            return methodResult;
        }
    }
}