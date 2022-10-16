using FuncSharp;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Marvin.Web.Code.HealthChecks
{
    /// <summary>
    /// Example Health Check
    /// </summary>
    public class ExampleHealthCheck : IHealthCheck
    {
        /// <summary>
        /// Example Health Check
        /// </summary>
        /// <param name="context">Current Health Check Context</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            return isHealthy.Match(
                t => Task.FromResult(HealthCheckResult.Healthy("A healthy result.")),
                f => Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result."))
            );
        }
    }
}
