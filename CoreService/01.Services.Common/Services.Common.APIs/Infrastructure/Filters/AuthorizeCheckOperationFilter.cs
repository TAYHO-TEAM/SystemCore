using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Services.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Common.APIs
{
    public class AuthorizeCheckOperationFilter : IAuthorizationFilter
    {
        private readonly EAuthorizeType _authorizeType;
        private readonly ECommandType _commandType;
        private readonly Type _type;

        public AuthorizeCheckOperationFilter(EAuthorizeType authorizeType, ECommandType commandType, Type type)
        {
            _authorizeType = authorizeType;
            _commandType = commandType;
            _type = type;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string controllerNamespace = _type.Namespace;
            string controllerName = (string)context.RouteData.Values["controller"];
            string actionName = (string)context.RouteData.Values["action"];
            if (_authorizeType == EAuthorizeType.Everyone) { return; }
            if (_authorizeType == EAuthorizeType.MusHavePermission)
            {
                var claims = context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "permissions");
                if (claims == null) context.Result = new ForbidResult();
            }
            if (_authorizeType == EAuthorizeType.AuthorizedUsers)
            {
                var claims = context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "permissions");
                if (claims != null)
                {
                    var permissions = JsonConvert.DeserializeObject<List<string>>(claims.Value);
                    if (!permissions.Contains(controllerNamespace + "_" + controllerName + "_" + actionName + "_" + _commandType))
                    {
                        context.Result = new ForbidResult();
                    }
                }
                else
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}