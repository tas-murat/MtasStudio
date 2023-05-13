using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Infrastructure.Context;
using MtasStudio.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MtasDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["MtasDbConnectionString"]);
                opt.EnableSensitiveDataLogging();
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            var optionsBuilder = new DbContextOptionsBuilder<MtasDbContext>()
                .UseSqlServer(configuration["MtasDbConnectionString"]);

            using var dbContext = new MtasDbContext(optionsBuilder.Options, null);
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            return services;
        }
    }
}
