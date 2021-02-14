using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.Interfaces;
using WebStore.Services;
using WebStore.Data;
using Microsoft.EntityFrameworkCore;
using WebStore.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using WebStore.Services.InCookies;
using WebStore.Services.SqlServer;

namespace WebStore
{

    public record Startup(IConfiguration Configuration)
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Db>(options => options
                .UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<DbInitializer>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Db>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
#if DEBUG
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 3;
#endif
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "WebStore.AT";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(10);

                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                options.SlidingExpiration = true;
            });

            services.AddTransient<IEmployeesService, InMemoryEmployeesService>();

            // services.AddTransient<IProductsService, InMemoryProductsService>();
            services.AddTransient<IProductsService, SqlServerProductsService>();
            services.AddTransient<IOrdersService, SqlServerOrdersService>();

            services.AddTransient<ICartService, InCookiesCartService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet(
                    "/test",
                    async context => await context.Response.WriteAsync(Configuration["TestMessage"]));

                endpoints.MapControllerRoute(
                   "default",
                   "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
