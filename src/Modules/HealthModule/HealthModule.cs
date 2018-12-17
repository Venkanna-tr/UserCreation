using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;

using Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthModule
{

    internal class HealthModule : IWebPlugin, IPluginLink
    {
        public string GetHref() => "/plugin/Health";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPluginLink, HealthModule>();
        }

        public void Configure(IApplicationBuilder appBuilder, IHostingEnvironment env)
        {
            appBuilder.Map("/plugin/Health", c =>
            {
                c.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World! from Health module");
                });
            });
        }
    }
}
