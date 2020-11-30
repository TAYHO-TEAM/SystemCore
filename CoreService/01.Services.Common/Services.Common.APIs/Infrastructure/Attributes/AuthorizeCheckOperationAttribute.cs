using System;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Security;

namespace Services.Common.APIs
{
    public class AuthorizeCheckOperationAttribute : TypeFilterAttribute
    {
        public AuthorizeCheckOperationAttribute(EAuthorizeType authorizeType, ECommandType commandType,Type type) : base(typeof(AuthorizeCheckOperationFilter))
        {
            Arguments = new object[] { authorizeType, commandType, type };
        }
    }
}