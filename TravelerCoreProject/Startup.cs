using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using TravelerCoreProject.CQRS.Handlers.DestinationHandlers;
using TravelerCoreProject.Models;

namespace TravelerCoreProject
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
            //CQRS serives:
            //GetAllDestinationQueryHandler i�in:
            services.AddScoped<GetAllDestinationQueryHandler>();
            //GetDestinationByIDQueryHandler i�in:
            services.AddScoped<GetDestinationByIDQueryHandler>();
            //CreateDestinationCommandHandler i�in:
            services.AddScoped<CreateDestinationCommandHandler>();
            //RemoveDestinationCommandHandler i�in:
            services.AddScoped<RemoveDestinationCommandHandler>();
            //UpdateDestinationCommandHandler i�in:
            services.AddScoped<UpdateDestinationCommandHandler>();

            //mediatR i�in:
            services.AddMediatR(typeof(Startup));


            //Log kay�tlar� i�in:
            services.AddLogging(x =>
            {
                x.ClearProviders();
                //1)VS outputta g�r�nt�leme:
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
                //2)Klas�r i�erisinde text dosyas�nda g�r�nt�leme:

            });

            //register i�lemleri i�in:
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

            //Web Api ba�lant�s�:
            services.AddHttpClient();

            //ef ba��ml���ndan kurtulmak i�in:
            services.ContainerDependencies();

            //AutoMapper :
            services.AddAutoMapper(typeof(Startup));
            //AnnouncementAddDTOs
            //services.AddTransient<IValidator<AnnouncementAddDto>,AnnouncementValidator>(); BL/Container-Extension'un i�ine ta��nd�.
            services.CustomValidator();



            services.AddControllersWithViews().AddFluentValidation();//


            //authorization i�lemi:
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
            //login i�lemine path verelim.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = "/ErrorPage/Error403";

            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LogoutPath = "/Login/LogOut/";
                    options.AccessDeniedPath = "/ErrorPage/Error403";
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //serilog.extensions.loggin.file i�lemleri i�in(log kay�tlar�n� klas�rde tutmak i�in):
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //404 error sayfas�na y�nlendirmek i�in:
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Authentication komutu:
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Areas:
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

        }
    }
}
