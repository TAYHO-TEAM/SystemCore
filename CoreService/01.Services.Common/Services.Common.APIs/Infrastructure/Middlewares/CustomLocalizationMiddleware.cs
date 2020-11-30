using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;

namespace Services.Common.APIs.Infrastructure
{
    public static class CustomLocalizationMiddleware
    {
        public static IApplicationBuilder UseCustomLocalization(this IApplicationBuilder app, IConfiguration configuration)
        {
            var defaultCulture = "vn-VN";
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo(defaultCulture),
                new CultureInfo("en-US")
            };
            var defaultRequestCulture = new RequestCulture(defaultCulture);
            try
            {
                var configSupportedCultures = configuration.GetSection("SupportedCultures").Get<string[]>();
                var configDefaultCulture = configuration["DefaultCulture"];
                if (!string.IsNullOrEmpty(configDefaultCulture))
                {
                    defaultCulture = configDefaultCulture;
                    defaultRequestCulture = new RequestCulture(defaultCulture);
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(defaultCulture);
                    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
                }
                if (configSupportedCultures != null && configSupportedCultures.Length > 0)
                {
                    foreach (var culture in configSupportedCultures)
                    {
                        var supportedCulture = new CultureInfo(culture);
                        if (!supportedCultures.Contains(supportedCulture)) supportedCultures.Add(supportedCulture);
                    }
                }
            }
            catch { }
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = defaultRequestCulture,
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            app.UseRequestLocalization(localizationOptions);
            return app;
        }
    }
}