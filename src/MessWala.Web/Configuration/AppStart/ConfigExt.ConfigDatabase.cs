using MessWala.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MessWala.Web.AppStart
{
    public static partial class ConfigExt
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            if (string.IsNullOrEmpty(config["DataProvider"])) return services;
            services.AddContext(config);
            return services;
        }

        /// <summary>
        /// Initialize the database with appropriate schema and content 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IApplicationBuilder InitializeData(this IApplicationBuilder app, IConfiguration config)
        {

            // Exit now if we don't have a data configuration
            if (string.IsNullOrEmpty(config["DataProvider"])) return app;

            var scope = app.ApplicationServices.CreateScope();
            var identityContext = scope.SeedData().ServiceProvider.GetService<SampleDbContext>();
            return app;
        }
    }
}
