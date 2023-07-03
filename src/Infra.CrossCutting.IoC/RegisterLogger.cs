using Infra.CrossCutting.Logging;
using Infra.CrossCutting.Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    /// <summary>
    /// Register DI Log
    /// </summary>
    public static class RegisterLogger
    {
        /// <summary>
        /// Extension to register the services
        /// </summary>
        /// <param name="services"></param>
        public static void ServicesLogger(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
        }
    }
}
