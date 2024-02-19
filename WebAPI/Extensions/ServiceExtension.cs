using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);

                config.AssumeDefaultVersionWhenUnspecified = true;

                config.ReportApiVersions = true;
            });
        }
    }
}
