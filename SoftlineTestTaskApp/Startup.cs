using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoftlineTestTaskApp.DAL;
using SoftlineTestTaskApp.DAL.Repositories;
using SoftlineTestTaskApp.Domain.Defenitions;
using SoftlineTestTaskApp.Domain.Repositories;

namespace SoftlineTestTaskApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region DbContext configuration

            var sqlServerProvider = Configuration.GetValue<string>(ConfigDefinitions.SQLServerProvider);
            var connectionString = Configuration.GetConnectionString(sqlServerProvider);

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            #endregion

            #region DI registration

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            #endregion
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

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
