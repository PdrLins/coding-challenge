using codingchallengeapi.Business.Interfaces;
using codingchallengeapi.Business.Services;
using codingchallengeapi.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace codingchallengeapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            var appSettings = new AppSettings();
            new ConfigureFromConfigurationOptions<AppSettings>(Configuration.GetSection("Settings")).Configure(appSettings);

            services.AddSingleton(appSettings);
            services.AddCors();
            services.AddMvc();
            services.AddScoped<IFileService,FileService>();
            services.AddScoped<ICSVRuleBuilder, CSVRuleBuilderService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(cors => 
                            cors.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                                );



            app.UseMvc(routes =>
            {
                routes.MapRoute("default_route", "api/{controller}/{action}/{id?}", new { controller = "Values", action = "Get" });
            });
        }
    }
}
