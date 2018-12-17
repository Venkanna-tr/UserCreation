using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using McMaster.NETCore.Plugins;
using MediatR;
using MediatR.Pipeline;
using MessWala.Application.Infrastructure;
using MessWala.Application.Restaurant.Commands;
using MessWala.Application.Restaurant.Queries;
using MessWala.Data;
using MessWala.Infrastructure;
using MessWala.Web.AppStart;
using MessWala.WebUI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Extensions;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Microsoft.AspNetCore.HttpsPolicy;
namespace MessWala.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string pluginsPath = string.Empty;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            pluginsPath = Path.Combine(_hostingEnvironment.ContentRootPath, "plugins");

            foreach (var pluginFile in Directory.GetFiles(pluginsPath, "plugin.config", SearchOption.AllDirectories))
            {
                var loader = PluginLoader.CreateFromConfigFile(pluginFile,
                    // this ensures that the plugin resolves to the same version of DependencyInjection
                    // and ASP.NET Core that the current app uses
                    sharedTypes: new[]
                    {
                        typeof(IApplicationBuilder),
                        typeof(IWebPlugin),
                        typeof(IServiceCollection),
                    });
                foreach (var type in loader.LoadDefaultAssembly().GetTypes().Where(t => typeof(IWebPlugin).IsAssignableFrom(t) && !t.IsAbstract))
                {
                    Console.WriteLine("Found plugin " + type.Name);
                    var plugin = (IWebPlugin)Activator.CreateInstance(type);
                    _plugins.Add(plugin);
                }
            }
        }

        public IConfiguration Configuration { get; }
        private List<IWebPlugin> _plugins = new List<IWebPlugin>();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            //GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            //services.AddModules(_hostingEnvironment.ContentRootPath);

            //TODO:KK for ref in plugins
            //services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.ConfigureDatabase(Configuration);

            //const string applicationAssemblyName = "MessWala.Application";
            //var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);
            //AssemblyScanner
            //   .FindValidatorsInAssembly(assembly)
            //    .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddMediatR(typeof(GetRestaurantListQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddHealthChecksUI();
            services.AddHealthChecks().AddDbContextCheck<SampleDbContext>("Data Server", tags: new string[] { "data server" })
            .AddCheck<RandomHealthCheck>("For Sample")
            .AddVirtualMemorySizeHealthCheck(4000000000000, "Virtual Memory")
            .AddDiskStorageHealthCheck(a => a.AddDrive(@"C:\", 10000), "Disk Memory");
            //services.AddHealthChecks().AddSqlServer(connectionString: Configuration["ConnectionStrings:SampleContext"]);

            foreach (var plugin in _plugins)
            {
                plugin.ConfigureServices(services);
            }

            //var sp = services.BuildServiceProvider();
            //var moduleInitializers = sp.GetServices<IModuleInitializer>();
            //foreach (var moduleInitializer in moduleInitializers)
            //{
            //    moduleInitializer.ConfigureServices(services);
            //}

            services.AddSingleton<OnDemandActionDescriptorChangeProvider>();
            services.AddSingleton<IActionDescriptorChangeProvider>(f => f.GetService<OnDemandActionDescriptorChangeProvider>());
            services.AddSingleton<ApplicationPartWatcher>();
            //options => options.Filters.Add(typeof(CustomExceptionFilterAttribute))

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRestaurantCommand>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationPartWatcher applicationPartWatcher)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.InitializeData(Configuration);

            //for json
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            foreach (var plugin in _plugins)
            {
                plugin.Configure(app, env);
            }

            //var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            //foreach (var moduleInitializer in moduleInitializers)
            //{
            //    moduleInitializer.Configure(app, env);
            //}

            app.UseHealthChecksUI();
            app.UseStaticFiles("/wwwroot");
            app.UseMvcWithDefaultRoute();
            applicationPartWatcher.LoadModules(pluginsPath);
            //Task.Run(() => applicationPartWatcher.Watch(pluginsPath));
        }
    }


    /// <summary>
    /// Just for sample
    /// </summary>
    public class RandomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (DateTime.UtcNow.Minute % 2 == 0)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }
            return Task.FromResult(HealthCheckResult.Unhealthy(description: "failed"));
        }
    }
}
