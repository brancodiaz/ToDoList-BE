using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain;

namespace ToDo.Persistence.Install
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection ConfigurePeristenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IToDoPersistenceService, ToDoPersistenceService>();
            return services;
        }
    }
}