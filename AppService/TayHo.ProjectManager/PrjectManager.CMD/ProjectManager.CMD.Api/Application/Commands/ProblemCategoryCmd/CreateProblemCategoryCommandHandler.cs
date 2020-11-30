﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateProblemCategoryCommandHandler : ProblemCategoryCommandHandler, IRequestHandler<CreateProblemCategoryCommand, MethodResult<CreateProblemCategoryCommandResponse>>
    {
        public CreateProblemCategoryCommandHandler(IMapper mapper, IProblemCategoryRepository ProblemCategoryRepository) : base(mapper, ProblemCategoryRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new ProblemCategory
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateProblemCategoryCommandResponse>> Handle(CreateProblemCategoryCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateProblemCategoryCommandResponse>();
            var newProblemCategory = new ProblemCategory(request.Title,
                                                        request.Descriptions,
                                                        request.Priotity);
            newProblemCategory.SetCreateAccount(0);
            newProblemCategory.Status = request.Status.HasValue ? request.Status : newProblemCategory.Status;
            newProblemCategory.IsActive = request.IsActive.HasValue ? request.IsActive : newProblemCategory.IsActive;
            newProblemCategory.IsVisible = request.IsActive.HasValue ? request.IsVisible : newProblemCategory.IsVisible;
            await _ProblemCategoryRepository.AddAsync(newProblemCategory).ConfigureAwait(false);
            await _ProblemCategoryRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateProblemCategoryCommandResponse>(newProblemCategory);
            return methodResult;
        }
    }
}