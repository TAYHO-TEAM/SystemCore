using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Services.Common.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.Common.APIs.Infrastructure
{
    public class CustomUserBlackListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _distributedCache;
        public CustomUserBlackListMiddleware(RequestDelegate next, IDistributedCache distributedCache)
        {
            _next = next;
            _distributedCache = distributedCache;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Items.Any(x => (string)x.Key == ClaimsTypeName.ACCOUNT_ID))
            {
                int currentUserId = (int)context.Items[ClaimsTypeName.ACCOUNT_ID];
                var result = await _distributedCache.GetStringAsync("ACL_BLU").ConfigureAwait(false);
                if (!string.IsNullOrEmpty(result))
                {
                    List<int> blackListOfUserIds = JsonConvert.DeserializeObject<List<int>>(result);
                    if (blackListOfUserIds.Any(x => x == currentUserId))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                }
            }
            await _next(context);
        }
    }
}