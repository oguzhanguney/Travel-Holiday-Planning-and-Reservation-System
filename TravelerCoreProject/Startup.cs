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
            //GetAllDestinationQueryHandler için:
            services.AddScoped<GetAllDestinationQueryHandler>();
            //GetDestinationByIDQueryHandler için:
            services.AddScoped<GetDestinationByIDQueryHandler>();
            //CreateDestinationCommandHandler için:
            services.AddScoped<CreateDestinationCommandHandler>();
            //RemoveDestinationCommandHandler için:
            services.AddScoped<RemoveDestinationCommandHandler>();
            //UpdateDestinationCommandHandler için:
            services.AddScoped<UpdateDestinationCommandHandler>();

            //mediatR için:
            services.AddMediatR(typeof(Startup));


            //Log kayýtlarý için:
            services.AddLogging(x =>
            {
                x.ClearProviders();
                //1)VS outputta görüntüleme:
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
                //2)Klasör içerisinde text dosyasýnda görüntüleme:

            });

            //register iþlemleri için:
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

            //Web Api baðlantýsý:
            services.AddHttpClient();

            //ef baðýmlýðýndan kurtulmak için:
            services.ContainerDependencies();

            //AutoMapper :
            services.AddAutoMapper(typeof(Startup));
            //AnnouncementAddDTOs
            //services.AddTransient<IValidator<AnnouncementAddDto>,AnnouncementValidator>(); BL/Container-Extension'un içine taþýndý.
            services.CustomValidator();



            services.AddControllersWithViews().AddFluentValidation();//


            //authorization iþlemi:
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMvc();
            //login iþlemine path verelim.
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
            //serilog.extensions.loggin.file iþlemleri için(log kayýtlarýný klasörde tutmak için):
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
            //404 error sayfasýna yönlendirmek için:
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
