using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Services.Common.APIs
{
    public static class APIProgramBase<T> where T : APIStartupBase
    {
        public static void Main(string[] args, Action<IHost> seedData)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Application Starting.");
                var host = CreateHostBuilder(args).Build();
                seedData(host);
                host.Run();
            }
            catch (Exception ex)
            {
                Console.ReadLine();
                Log.Fatal(ex, "The Application failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<T>();
            });
    }
}