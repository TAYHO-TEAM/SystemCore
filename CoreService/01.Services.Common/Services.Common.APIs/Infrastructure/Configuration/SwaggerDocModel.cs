using Microsoft.OpenApi.Models;

namespace Services.Common.APIs.Infrastructure.Configuration
{
    public class SwaggerDocModel
    {
        public string Name { get; set; }
        public OpenApiInfo OpenApiInfo { get; set; }
    }
}