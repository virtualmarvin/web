using FuncSharp;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Marvin.Web.HealthChecks
{
    public class ExampleHealthCheck : IHealthCheck
    {
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
