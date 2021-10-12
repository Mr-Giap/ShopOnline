using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShopOnline.Aplication.Implement;
using ShopOnline.Aplication.Implement.Client;
using ShopOnline.Aplication.Interface.Admin;
using ShopOnline.Aplication.Interface.Client;
using ShopOnline.Data.Entities;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI
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

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/dang-nhap";// trang này để ứng dụng chuyển hướng đến nếu truy cập chức năng nào đó cần User phải đăng nhập.
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied"; //trang ứng dụng chuyển hướng đến nếu User truy cập chức năng nào đó mà không được phân quyền
                options.SlidingExpiration = true;
            });

            //services
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
          
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ISlideService, SlideService>();
            //client
            services.AddScoped<IProductServiceClient, ProductServiceClient>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICategoryServiceClient, CategoryServiceClient>();
            services.AddScoped<IBillServiceClient, BillServiceClient>();
            services.AddScoped<IColorServiceClient, ColorServiceClient>();
            services.AddScoped<ITagServiceClient, TagServiceClient>();


            //services.AddDatabaseDeveloperPageExceptionFilter();
            /*services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();*/
            services.AddRazorPages();
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopOnlineAPI", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopOnlineAPI v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
