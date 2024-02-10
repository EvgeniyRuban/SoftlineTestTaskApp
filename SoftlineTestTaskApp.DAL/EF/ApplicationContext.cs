using Microsoft.EntityFrameworkCore;
using SoftlineTestTaskApp.Domain.Entities;

namespace SoftlineTestTaskApp.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
