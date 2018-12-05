using System;
using System.Diagnostics;
using Keystone.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mvc.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var builder = services.AddKeystone(Configuration);
            builder = builder.AddCore(options =>
            {
                Console.WriteLine("AddCore");
            });
            builder = builder.AddServer(options =>
            {
                Console.WriteLine("AddServer");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.Use( (context, next) =>
            {
                 context.ApiResponse(new {my = "JSON", response = "Object"});
                return next();
            });

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}