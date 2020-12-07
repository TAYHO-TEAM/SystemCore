using Acc.Common;
using Acc.Read.Api.Controllers.v1.BaseClasses;
using Acc.Read.Api.ViewModels;
using Acc.Read.Api.ViewModels.BaseClasses;
using Acc.Read.Sql.DTOs;
using Acc.Read.Sql.Interfaces;
using Acc.Read.Sql.Parameters;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Acc.Read.Api.Controllers.v1
{

    public class GroupFunctionController : APIControllerBase
    {
        private readonly IDOBaseRepository<GroupFunctionDTO> _dOBaseRepository;

        public GroupFunctionController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<GroupFunctionDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of GroupFunction.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<GroupFunctionResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGroupFunctionAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<GroupFunctionResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.GroupFunction_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<GroupFunctionResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<GroupFunctionResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

