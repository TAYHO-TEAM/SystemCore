using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;
using ProjectManager.Read.Api.ViewModels.DevExpressClasses;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Api.Controllers.v1
{
    public class ProjectManagerController : APIControllerBase
    {
        
        private const string getAll = nameof(getAll);
        private readonly IProjectManagerRepository _projectManagerRepository;
        public ProjectManagerController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IProjectManagerRepository projectManagerRepository) : base(mapper,httpContextAccessor)
        {
            _projectManagerRepository = projectManagerRepository;
        }
        /// <summary>
        /// Get List of ProjectManager get.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //[Route(getAll)]
        public async Task<IActionResult> GetProjectManager([FromBody]DevRequestViewModel loadOptions)
        {
            DevLoadOptionsBase requestFilter = _mapper.Map<DevRequestLoadOptionsViewModel, DevLoadOptionsBase>(loadOptions.devRequestLoadOptionsViewModel);
            return Ok(await _projectManagerRepository.GetAccount(loadOptions.nameEF, requestFilter));
            //return Ok("abc");
        }
        //public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        //{
        ////    var orders = _dbContext.AccountInfo.Select(i => new
        ////    {
        ////        i.AccountId,
        ////        i.AccountName,
        ////        i.CreateBy
        ////    });
        //    return Ok(await DataSourceLoader.LoadAsync(orders, loadOptions));
        //}

    }
}
