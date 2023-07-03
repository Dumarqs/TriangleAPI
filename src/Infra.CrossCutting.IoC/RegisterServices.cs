using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Interfaces;

namespace Infra.CrossCutting.IoC
{
    public static class RegisterServices
    {
        public static void ServicesApplication(this IServiceCollection services)
        {
            services.AddScoped<ITriangleService, TriangleService>();
        }
    }
}
