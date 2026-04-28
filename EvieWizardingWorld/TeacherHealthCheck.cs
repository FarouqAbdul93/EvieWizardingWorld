using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

namespace EvieWizardingWorld
{
    public class TeacherHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
           
                string filePath = "Resources/Teachers.json";
                string jsonText = await File.ReadAllTextAsync(filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var teachers = JsonSerializer.Deserialize<List<object>>(jsonText, options);

                int teacherCount = teachers.Count();

            if (teacherCount > 0)
                {
                    return HealthCheckResult.Healthy($"There are {teacherCount} teachers available.");
                }
                else
                {
                    return HealthCheckResult.Unhealthy($"There are {teacherCount} no teachers available.");
                }
            
           
        }
    }
}
