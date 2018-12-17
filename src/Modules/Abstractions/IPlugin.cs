using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Plugin.Abstractions
{
    public interface IWebPlugin
    {
        void Configure(IApplicationBuilder appBuilder, IHostingEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }
}
