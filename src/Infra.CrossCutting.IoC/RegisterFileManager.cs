using Infra.CrossCutting.FileManager;
using Infra.CrossCutting.FileManager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public static class RegisterFileManager
    {
        public static void ServicesFileManager(this IServiceCollection services)
        {
            services.AddScoped<ILoadTextFile, LoadTextFile>();
        }
    }
}
