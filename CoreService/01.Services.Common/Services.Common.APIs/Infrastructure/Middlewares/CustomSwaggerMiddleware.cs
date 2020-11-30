using Microsoft.AspNetCore.Builder;

namespace Services.Common.APIs.Infrastructure
{
    public static class CustomSwaggerMiddleware
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(); // Enable middleware to serve swagger-ui(HTML, JS, CSS, etc.),
            app.UseSwaggerUI(c =>
            {
                //c.OAuthClientId("swagger");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TayHo.QuanLyDuAn API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "TayHo.QuanLyDuAn API V2");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            return app;
        }
    }
}