using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Services.Common.APIs.Cmd.EF
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomDbContext<TContext>(this IServiceCollection services) where TContext : DbContext => services.AddCustomDbContext<TContext>(ApplyDbOptions);

        public static void AddCustomDbContext<TContext>(this IServiceCollection services, Action<IServiceProvider, DbContextOptionsBuilder> optionsAction) where TContext : DbContext => services.AddEntityFrameworkSqlServer().AddDbContext<TContext>(optionsAction);

        private static void ApplyDbOptions(IServiceProvider serviceProvider, DbContextOptionsBuilder options)
        {
            var optionsBuilder = serviceProvider.GetService<IOptionsBuilder>();
            var sqlServerOptions = optionsBuilder.ReadSqlServerOptionsSettings();
            var entryAssembly = Assembly.GetEntryAssembly();
            options.UseSqlServer(sqlServerOptions.ConnectionStrings, opt =>
            {
                opt.MigrationsAssembly(entryAssembly.GetName().Name);
                opt.EnableRetryOnFailure(
                    maxRetryCount: sqlServerOptions.MaxRetryCount,
                    maxRetryDelay: TimeSpan.FromSeconds(sqlServerOptions.MaxRetryDelayInSecond),
                    errorNumbersToAdd: null
                );
            });
        }
    }
}