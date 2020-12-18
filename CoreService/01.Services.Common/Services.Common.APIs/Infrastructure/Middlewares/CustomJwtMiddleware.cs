using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Services.Common.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.APIs.Infrastructure
{
    public class CustomJwtMiddleware
    {
        private readonly IOptionsBuilder _optionsBuilder;
        private readonly RequestDelegate _next;

        public CustomJwtMiddleware(RequestDelegate next, IOptionsBuilder optionsBuilder)
        {
            _next = next;
            _optionsBuilder = optionsBuilder;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null) AttachUserToContext(context, token);
            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var jwtOptions = _optionsBuilder.ReadJwtOptionsSettings();
                //if (!string.IsNullOrEmpty(jwtOptions.SecretKey)) return;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsTypeName.ACCOUNT_ID).Value);
                context.Items[ClaimsTypeName.ACCOUNT_ID] = userId;
            }
            catch (Exception ex)
            {
                // do nothing if jwt validation fails
                throw;
            }
        }
    }
}