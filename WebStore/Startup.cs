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

namespace WebStore
{

    public record Startup(IConfiguration Configuration)
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Db>(options => options
                .UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<DbInitializer>();

            services.AddTransient<IEmployeesService, EmployeesService>();

            services.AddTransient<IProductsService, ProductsService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
