using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftlineTestTaskApp.Domain.Entities;

namespace SoftlineTestTaskApp.DAL.EF.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasAlternateKey(nameof(Status.Name));
        }
    }
}
