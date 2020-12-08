﻿using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class WorkItemsCommandHandler :BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IWorkItemsRepository _WorkItemsRepository;

        public WorkItemsCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IWorkItemsRepository WorkItemsRepository) :  base (httpContextAccessor)
        {
            _mapper = mapper;
            _WorkItemsRepository = WorkItemsRepository;
        }
    }
}