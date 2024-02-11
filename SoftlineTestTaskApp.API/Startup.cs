using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftlineTestTaskApp.DAL;
using SoftlineTestTaskApp.DAL.Repositories;
using SoftlineTestTaskApp.Domain.Defenitions;
using SoftlineTestTaskApp.Domain.Repositories;
using SoftlineTestTaskApp.Domain.Services;
using SoftlineTestTaskApp.Services.Services;

namespace SoftlineTestTaskApp.API
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
            #region Database context configuring

            var sqlServerProvider = Configuration.GetValue<string>(ConfigDefinitions.SQLServerProvider);
            var connectionString = Configuration.GetConnectionString(sqlServerProvider);

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            #endregion

            #region Services DI registration

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IStatusService, StatusService>();

            #endregion

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
