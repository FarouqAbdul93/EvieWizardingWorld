using EvieWizardingWorld.Models;
using EvieWizardingWorld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using EvieWizardingWorld;

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


            var app = builder.Build();

            app.UseRouting();

            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
