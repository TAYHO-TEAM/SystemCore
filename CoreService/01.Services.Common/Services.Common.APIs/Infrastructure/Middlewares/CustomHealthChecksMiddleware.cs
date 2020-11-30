using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Services.Common.APIs.Infrastructure
{
    public static class CustomHealthChecksMiddleware
    {
        public static IApplicationBuilder UseCustomHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse //nuget: AspNetCore.HealthChecks.UI.Client,
            });
            app.UseHealthChecksUI();
            return app;
        }
    }
}