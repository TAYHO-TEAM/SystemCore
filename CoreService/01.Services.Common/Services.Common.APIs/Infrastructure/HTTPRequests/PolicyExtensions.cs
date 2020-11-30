using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Extensions.Http;

namespace Services.Common.APIs.Infrastructure.HTTPRequests
{
    public static class PolicyExtensions
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
        {
            var retryCount = configuration.GetValue<int>("HttpConfig:RetryCount");
            var sleepDuration = configuration.GetValue<int>("HttpConfig:SleepDuration");
            var jitterer = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(sleepDuration, retryAttempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0,100)));
        }
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(IConfiguration configuration)
        {
            var allowedBeforeBreaking = configuration.GetValue<int>("HttpConfig:AllowedBeforeBreaking");
            var durationOfBreak = configuration.GetValue<int>("HttpConfig:DurationOfBreak");

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(allowedBeforeBreaking, TimeSpan.FromSeconds(durationOfBreak));
        }
    }
}