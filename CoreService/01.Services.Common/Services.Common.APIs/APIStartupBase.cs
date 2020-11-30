using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Common.APIs.Infrastructure.DIServiceConfigurations;
using System;
using Services.Common.APIs.Infrastructure;

namespace Services.Common.APIs
{
    public abstract class APIStartupBase
    {
        public IConfiguration Configuration;
        public IWebHostEnvironment WebHostEnvironment;
        public ILifetimeScope AutofacContainer;
        protected APIStartupBase(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration)); ;
            WebHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        }
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            ConfigureHttpClients(services);
            services.AddCustomMvc(Configuration);
        }
        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseCustomMvc(Configuration);
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
        }
        public virtual void ConfigureHttpClients(IServiceCollection services)
        {
        }
    }
}