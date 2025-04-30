using Amazon.S3;
using MagicSite.Data;
using MagicSite.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicSite
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

         services.AddRouting(options => options.LowercaseUrls = true);

         services.AddCors(options =>
         options.AddPolicy("MyAllowedCORS", policy =>
         {

             policy.WithOrigins("http://localhost:44304").AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true);
         })
         );

          //  services.AddDbContext<EndorsedContextDb>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddControllers();
            services.AddSingleton<DataBaseConnection>();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            
            services.AppService();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("MyAllowedCORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //Consumer Route
                endpoints.MapAreaControllerRoute(
                    name: "Consumer",
                    areaName: "Consumer",
                    pattern: "Consumer/{controller=Consumers}/{action=Index}/{id?}");


                //Shop Owner Route
                endpoints.MapAreaControllerRoute(
                    name: "Shop",
                    areaName: "Shop",
                    pattern: "Shop/{controller=Shops}/{action=Index}/{id?}");

                //SiteAdmin Route
                endpoints.MapAreaControllerRoute(
                    name: "SiteOwner",
                    areaName: "SiteAdmin",
                    pattern: "SiteAdmin/{controller=SiteOwners}/{action=Index}/{id?}");



                //Default Route
                endpoints.MapControllerRoute(
                    name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");

                //Web API Exposure
                endpoints.MapControllers();
            });

                
        }
    }
}
