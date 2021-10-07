﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.Data;
using ShopOnline.Data.Entities;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // Vòng đời của Dependency Injection: Transient, Singleton và Scoped.
        // Transient :   Mỗi lần request thì nó gọi đến thằng này
        // Scoped  : Mỗi khi khởi tạo 1 dêpndecy thì nó add thêm vào
        // Singleton : Khởi tạo 1 lần duy nhất. Khi chạy project cho đến khi store project thì mới hết.
        public IConfiguration Configuration { get; }
          
        public void ConfigureServices(IServiceCollection services)
        {
            // add database vào severvip
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            // add identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            // seed data 
           services.AddTransient<DbInitializer>();

            //services

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
            //services.AddDatabaseDeveloperPageExceptionFilter();
            /*services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();*/
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Chạy qua các middiewere từ trên xuống dưới(gọi là 1 vòng đời netcore)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();    // Phần trung gian chuyển hướng từ yêu cầu http sang https.
            app.UseStaticFiles();       // Cho phép cấp phát tĩnh theo yêu cầu hiện tại.
            app.UseRouting();          //Là phần trung gian routing của Middleware vào để builder application 
            app.UseAuthentication();   // Thêm Authentication.AuthenticationMiddleware vào Microsoft.AspNetCore.Builder.IApplicationBuilder được chỉ định, cho phép xác thực.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
