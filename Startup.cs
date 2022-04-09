using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using projekUas_Atun.Models;
using projekUas_Atun.Repository.MemberRepository;
using projekUas_Atun.Repository.MobilRepository;
using projekUas_Atun.Repository.PaketRepository;
using projekUas_Atun.Repository.PeminjamanRepository;
using projekUas_Atun.Repository.SupirRepository;
using projekUas_Atun.Services;
using projekUas_Atun.Services.MemberServices;
using projekUas_Atun.Services.MobilServices;
using projekUas_Atun.Services.PaketServices;
using projekUas_Atun.Services.PeminjamanServices;
using projekUas_Atun.Services.SupirServices;
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
            services.AddTransient<EmailService>();
            services.Configure<Email>(Configuration.GetSection("AturEmail"));

            services.AddScoped<IMemberRepository,MemberRepository>();
            services.AddScoped<IMemberServices, MemberServices>();

            services.AddTransient<FileServices>();

            services.AddControllersWithViews();

            services.AddScoped<IMobilRepository, MobilRepository>();
            services.AddScoped<IMobilServices, MobilServices>();

            services.AddScoped<IPaketRepository, PaketRepository>();
            services.AddScoped<IPaketServices, PaketServices>();

            services.AddScoped<ISupirRepository, SupirRepository>();
            services.AddScoped<ISupirServices, SupirServices>();

            services.AddScoped<IPeminjamanRepository, PeminjamanRepository>();
            services.AddScoped<IPeminjamanServices, PeminjamanServices>();

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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AreaAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "AreaUser",
                    areaName: "User",
                    pattern: "User/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Akun}/{action=Masuk}/{id?}");
            });
        }
    }
}
