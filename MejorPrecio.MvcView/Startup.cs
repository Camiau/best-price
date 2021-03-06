﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading.Tasks;

namespace MejorPrecio.MvcView
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
            services.AddMvc();
            // configuramos autenticacion por cookies solor
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(option =>
                {
                    option.Events.OnRedirectToLogin =  context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };

                    option.Events.OnRedirectToAccessDenied =  context =>
                    {
                        context.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    };
                });
            // configuramos autenticacion por cookies y custom
            //     services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //         .AddCookie(option =>
            //         {
            //             option.Events.OnRedirectToLogin = async context =>
            //             {
            //                 context.Response.StatusCode = 401;
            //             };

            //             option.Events.OnRedirectToAccessDenied = async context =>
            //             {
            //                 context.Response.StatusCode = 403;
            //             };
            //         });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Activamos autenticacion
            app.UseAuthentication();

            app.UseStaticFiles();
           /* app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), "img")),
                RequestPath = "/img"
            });*/


            /*app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "img")),
                RequestPath = "/img"
            });¨*/

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
