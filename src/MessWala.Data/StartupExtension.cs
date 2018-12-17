using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessWala.Data
{

    public static class StartupExtensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
        {
            Action<DbContextOptionsBuilder> optionsBuilder;
            var connectionString = config.GetConnectionString("SampleContext");

            switch (config["DataProvider"].ToLowerInvariant())
            {
                case "postgres":
                    services.AddEntityFrameworkNpgsql();
                    optionsBuilder = options => options.UseNpgsql(connectionString);
                    break;
                case "sqlserver":
                    services.AddEntityFrameworkSqlServer();
                    optionsBuilder = options => options.UseSqlServer(connectionString);
                    break;
                default:
                    services.AddEntityFrameworkSqlite();
                    connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : "DataSource=./App_Data/sample.db";
                    optionsBuilder = options => options.UseSqlite(connectionString);
                    break;
            }

            services.AddDbContextPool<SampleDbContext>(options =>
            {
                optionsBuilder(options);
                options.EnableSensitiveDataLogging();
            });
            return services;
        }

        public static IServiceScope SeedData(this IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetService<SampleDbContext>();
            return serviceScope;

        }
    }
}
