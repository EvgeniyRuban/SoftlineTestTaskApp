using SoftlineTestTaskApp.Domain.Entities;

namespace SoftlineTestTaskApp.Domain.Repositories
{
    public interface IStatusRepository : ICrudRepository<Status, int>
    {
    }
}