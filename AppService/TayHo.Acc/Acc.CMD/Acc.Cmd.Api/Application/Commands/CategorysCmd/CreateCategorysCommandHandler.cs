using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateCategorysCommandHandler : CategorysCommandHandler, IRequestHandler<CreateCategorysCommand, MethodResult<CreateCategorysCommandResponse>>
    {
        public CreateCategorysCommandHandler(IMapper mapper, ICategorysRepository CategorysRepository) : base(mapper, CategorysRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Categorys
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCategorysCommandResponse>> Handle(CreateCategorysCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCategorysCommandResponse>();
            var newCategorys = new Categorys(request.Title,
                                               request.Descriptions);
            newCategorys.Status = request.Status.HasValue ? request.Status : newCategorys.Status;
            newCategorys.IsActive = request.IsActive.HasValue ? request.IsActive : newCategorys.IsActive;
            newCategorys.IsVisible = request.IsActive.HasValue ? request.IsVisible : newCategorys.IsVisible;
            await _CategorysRepository.AddAsync(newCategorys).ConfigureAwait(false);
            await _CategorysRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCategorysCommandResponse>(newCategorys);
            return methodResult;
        }
    }
}