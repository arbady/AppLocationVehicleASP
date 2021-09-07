using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Services;
using AppLocationVehicleASP.Services.Base;
using AppLocationVehicleASP.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP
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
            services.AddControllersWithViews();


            //services.AddMvc();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //    .AddCookie(options =>
            //    {
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //        options.Cookie.Name = "mvcimplicit";
            //    })
            //    .AddOpenIdConnect("oidc", options =>
            //    {
            //        options.ClientId = "MvcClient";
            //        options.Authority = "https://localhost:15148";
            //        options.RequireHttpsMetadata = false;
            //        options.GetClaimsFromUserInfoEndpoint = true;
            //        options.ResponseType = "code token";

            //        options.Scope.Clear();
            //        options.Scope.Add("openid");
            //        options.Scope.Add("sitecore.profile");
            //        options.Scope.Add("offline_access");
            //        options.Scope.Add("sitecore.profile.api");

            //        options.SaveTokens = true;

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            NameClaimType = JwtClaimTypes.Name,
            //            RoleClaimType = JwtClaimTypes.Role,
            //        };
            //    });

            //Sessions
            services.AddSession(
                options => {
                    options.IdleTimeout = TimeSpan.FromMinutes(10); //Durée de vie de ma sessions
                    //options.Cookie.MaxAge = TimeSpan.FromMinutes(10);
                    //options.Cookie.Name = "AppLocationCookie";
                    //options.Cookie.Domain = "www.technofuturtic.com";
                    options.Cookie.HttpOnly = true; // Important!!! Empeche les scripts clients de 
                                                    //lire/ecrire dans le cookie
                                                    //options.Cookie.Expiration = TimeSpan.FromHours(1);
                    options.Cookie.IsEssential = true;
                });

            //Injection IHttpContextAccessor pour permettre
            //l'utilisation des sessions dans les classes non mvc
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<ISecurity>(new Security("http://localhost:15148/api/"));

            //Injection de nos services
            //services.AddScoped<Mailer>();
            services.AddScoped<HttpClient>();
            services.AddScoped<SmtpClient>();

            services.AddScoped<IService<Agency, AgencyForm>, AgencyService>();
            services.AddScoped<IService<Reservation, ReservationForm>, ReservationService>();
            services.AddScoped<IServiceUser<User, UserForm>, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            //Permet à notre classe de gestion de session de résoudre
            //les services
            SessionUtils.Services = app.ApplicationServices;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
