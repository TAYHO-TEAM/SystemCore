using AutoMapper;
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
    public class NS_LoaiThauController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_LoaiThauDTO> _dOBaseRepository;

        public NS_LoaiThauController(IMapper mapper, IDOBaseRepository<NS_LoaiThauDTO> dOBaseRepository) : base(mapper)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of NS_LoaiThau.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_LoaiThauResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_LoaiThauAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_LoaiThauResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_LoaiThau_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_LoaiThauResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_LoaiThauResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
