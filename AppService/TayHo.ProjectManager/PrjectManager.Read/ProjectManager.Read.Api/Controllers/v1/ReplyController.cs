﻿using AutoMapper;
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
    public class ReplyController : APIControllerBase
    {
        private readonly IDOBaseRepository<ReplyDTO> _dOBaseRepository;

        public ReplyController(IMapper mapper, IDOBaseRepository<ReplyDTO> dOBaseRepository) : base(mapper)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of Reply.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ReplyResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReplyAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ReplyResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.Reply_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ReplyResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ReplyResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
