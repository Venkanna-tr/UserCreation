using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Plugin.Abstractions;
using Microsoft.AspNetCore.Http;
using Abstractions;
using Microsoft.Extensions.Configuration;

namespace SuperAdminModule
{

    internal class SuperAdminModule : IWebPlugin, IPluginLink
    {
        public string GetHref() => "/plugin/SuperAdmin";
        //public IConfiguration config;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPluginLink, SuperAdminModule>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddMiniProfiler(options =>
            //{
            //    // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

            //    // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
            //    options.RouteBasePath = "/profiler";

            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
            app.Map("/plugin/SuperAdmin", c =>
            {
                c.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Hello World! from Super Admin module");
                });


            });
        }
    }
}
