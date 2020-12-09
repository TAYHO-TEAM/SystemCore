﻿using AutoMapper;
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
    public class NS_HangMucController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_HangMucDTO> _dOBaseRepository;
        private const string Treelist = nameof(Treelist);

        public NS_HangMucController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<NS_HangMucDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of NS_HangMuc.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_HangMucResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_HangMucAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_HangMucResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_HangMuc_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_HangMucResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_HangMucResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of NS_HangMuc.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Treelist)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_HangMucResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_HangMucTreeListAsync([FromQuery] BaseTreeRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_HangMucResponseViewModel>>();
            RequestTreeListBaseFilterParam requestFilter = _mapper.Map<RequestTreeListBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_HangMuc_TABLENAME;
            var queryResult = await _dOBaseRepository.GetTreeListWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_HangMucResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_HangMucResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
