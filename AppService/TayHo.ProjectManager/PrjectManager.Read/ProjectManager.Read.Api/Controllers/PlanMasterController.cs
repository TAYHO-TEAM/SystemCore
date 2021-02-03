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
    public class PlanMasterController : APIControllerBase
    {
        private readonly IDOBaseRepository<PlanMasterDTO> _dOBaseRepository;
        private readonly IPlanMasterRepository<PlanMasterAccountDTO> _planMasterRepository;
        private const string GetWithAccount = nameof(GetWithAccount);
        private const string GetWithAccountProgress = nameof(GetWithAccountProgress);
        public PlanMasterController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<PlanMasterDTO> dOBaseRepository,IPlanMasterRepository<PlanMasterAccountDTO> planMasterRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _planMasterRepository = planMasterRepository;
        }

        /// <summary>
        /// Get List of PlanMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanMasterResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanMasterAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanMasterResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanMaster_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanMasterResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanMasterResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }

        /// <summary>
        /// Get List of PlanMaster By Account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetWithAccount)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanMasterAccountResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanMasterAccountAsync([FromQuery] BasePermitRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanMasterAccountResponseViewModel>>();
            RequestHasAccountPermitFilterParam requestFilter = _mapper.Map<RequestHasAccountPermitFilterParam>(request);
            requestFilter.AccountId = _user;
            requestFilter.TableName = QuanLyDuAnConstants.PlanMaster_TABLENAME;

            var queryResult = await _planMasterRepository.GetWithPaggingPermistionAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanMasterAccountResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanMasterAccountResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }

        /// <summary>
        /// Get List of PlanMaster By Progress.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetWithAccountProgress)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanMasterAccountResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanMasterAccountProgressAsync([FromQuery] BasePermitRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanMasterAccountResponseViewModel>>();
            RequestHasAccountPermitFilterParam requestFilter = _mapper.Map<RequestHasAccountPermitFilterParam>(request);
            requestFilter.AccountId = _user;
            requestFilter.TableName = QuanLyDuAnConstants.PlanMaster_TABLENAME;
            requestFilter.FindId = string.IsNullOrEmpty(requestFilter.FindId) ? "PlanProjectId,1" : requestFilter.FindId;
            

            var queryResult = await _planMasterRepository.GetWithPaggingPermistionAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanMasterAccountResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanMasterAccountResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
