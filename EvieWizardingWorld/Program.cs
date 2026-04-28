using EvieWizardingWorld;
using EvieWizardingWorld.Models;
using EvieWizardingWorld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;
namespace EvieWizardingWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<SpellsService>();
            builder.Services.AddScoped<SpellsModel>();
            builder.Services.AddScoped<TeachersService>();
            builder.Services.AddScoped<TeachersModel>();
            builder.Services.AddHealthChecks()
                .AddCheck<TeacherHealthCheck>("teacher_file_health_check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "file", "teachers" });

            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter(policyName: "fixed", options =>
                {
                    options.PermitLimit = 3;
                    options.Window = TimeSpan.FromMinutes(1);
                    options.QueueLimit = 0;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });
                options.RejectionStatusCode = 429;
            });

            var app = builder.Build();

            app.UseRouting();
            app.UseRateLimiter();
            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
