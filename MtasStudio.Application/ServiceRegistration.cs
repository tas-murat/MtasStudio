using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace MtasStudio.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assm));
            return services;
        }
    }
}
