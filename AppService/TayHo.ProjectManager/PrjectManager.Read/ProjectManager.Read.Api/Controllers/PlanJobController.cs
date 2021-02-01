using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.Read.Api.Controllers.v1
{
    public class PlanJobController : APIControllerBase
    {
        private readonly IDOBaseRepository<PlanJobDTO> _dOBaseRepository;

        public PlanJobController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<PlanJobDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of PlanJob.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanJobResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanJobAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanJobResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanJob_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanJobResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanJobResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
