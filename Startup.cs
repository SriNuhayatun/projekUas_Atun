using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Repository;
using projekUas_Atun.Views.Services.MemberServices;
using projekUas_Atun.Views.Services.MobilServices;
using projekUas_Atun.Views.Services.PaketService;
using projekUas_Atun.Views.Services.SupirServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql")); //sesuaikan namanya
            });
            services.AddAuthentication("CookieAuth")
                    .AddCookie("CookieAuth", options =>
                    {
                        options.LoginPath = "/Akun/Masuk";
                    }
            );

            services.AddControllersWithViews();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberServices, MemberServices>();
            services.AddTransient<FileService>();

            services.AddScoped<IMobilRepository, MobilRepository>();
            services.AddScoped<IMobilServices, MobilServices>();
            services.AddTransient<FileServiceMobil>();

            services.AddScoped<IPaketRepository, PaketRepository>();
            services.AddScoped<IPaketService, PaketService>();

            services.AddScoped<ISupirRepository, SupirRepository>();
            services.AddScoped<ISupirServices, SupirSevices>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
