using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;

namespace minedu.rrhh.personal.servidorpublico.backend.Health
{
    public static class HealthCheckExtensions
    {
        public static IEndpointConventionBuilder MapCustomHealthChecks(this IEndpointRouteBuilder endpoints, string serviceName)
        {
            return endpoints.MapHealthChecks("/healthcheck", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = false,
                        IgnoreNullValues = true
                    };
                    var result = JsonSerializer.Serialize(
                        new HealthResult
                        {
                            Name = serviceName,
                            Status = report.Status.ToString(),
                            Duration = report.TotalDuration,
                            Info = report.Entries.Select(e => new HealthInfo
                            {
                                Key = e.Key,
                                Description = e.Value.Description,
                                Duration = e.Value.Duration,
                                Status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                Error = e.Value.Exception?.Message
                            }).ToList()
                        }, options);
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });
        }
    }
}
