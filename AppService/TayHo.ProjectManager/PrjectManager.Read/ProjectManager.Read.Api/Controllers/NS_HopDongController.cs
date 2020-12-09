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
    public class NS_HopDongController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_HopDongDTO> _dOBaseRepository;
        private const string Treelist = nameof(Treelist);

        public NS_HopDongController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<NS_HopDongDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of NS_HopDong.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_HopDongResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_HopDongAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_HopDongResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_HopDong_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_HopDongResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_HopDongResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of NS_HopDong.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Treelist)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_HopDongResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_HopDongTreeListAsync([FromQuery] BaseTreeRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_HopDongResponseViewModel>>();
            RequestTreeListBaseFilterParam requestFilter = _mapper.Map<RequestTreeListBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_HopDong_TABLENAME;
            var queryResult = await _dOBaseRepository.GetTreeListWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_HopDongResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_HopDongResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
