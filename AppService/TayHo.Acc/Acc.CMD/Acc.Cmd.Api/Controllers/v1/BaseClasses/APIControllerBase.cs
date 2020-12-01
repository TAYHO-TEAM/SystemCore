﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System;
using System.Security.Claims;

namespace Acc.Cmd.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.CommandAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ClaimsPrincipal User { get; }
        public APIControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}