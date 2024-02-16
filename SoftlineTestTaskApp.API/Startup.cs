using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SoftlineTestTaskApp.DAL;
using SoftlineTestTaskApp.DAL.Repositories;
using SoftlineTestTaskApp.Domain.Definitions;
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
            var migrationAssembly = string.Concat(ApplicationConstants.AssemblyCommonName, '.', sqlServerProvider);

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString, o => o.MigrationsAssembly(migrationAssembly));
            });

            #endregion

            #region Services DI registration

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IStatusService, StatusService>();

            #endregion

            #region Init swagger doc
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}