using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Models;
using GymApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GymApp
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<GymContext>();
            if (_env.IsEnvironment("Development"))
            {
                //crea la clase debugMail service cuando la precisa y la puede mantener cacheada
                //services.AddTransient<IMailService, DebugMailService>();
                //crea una vez la clase y luego la pasa una y otra vez
                //services.AddSingleton<IMailService, DebugMailService>();
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //implement real mail service
            }

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            //first try see if index file exists files from wwwroot
            //app.UseDefaultFiles();

            //With this we can serve files from wwwroot
            app.UseStaticFiles();


            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                );
            });

            /*
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/

        }
    }
}
