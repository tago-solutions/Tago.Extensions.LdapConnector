using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdManager.Api.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tago.Ldap.AdUtils;

namespace AdManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ctx = new AdContext
            {
                ad_root = "dc=tago,dc=com",
                port = 636,
                serverIp = "192.168.59.128",              
                userName = @"userName",
                password = "************",
                domain = "tago.com",
            };
            AdUserManager userManager = new AdUserManager(ctx);
            services.AddSingleton<AdUserService>();
            services.AddSingleton(userManager);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
