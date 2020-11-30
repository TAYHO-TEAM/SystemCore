using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System;

namespace ProjectManager.Read.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.ReadAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly IMapper _mapper;

        public APIControllerBase(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
