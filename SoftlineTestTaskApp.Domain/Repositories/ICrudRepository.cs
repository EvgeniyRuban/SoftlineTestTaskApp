using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.Domain.Repositories
{
    public interface ICrudRepository<TEntity, TId>
        where TId : struct
        where TEntity : Entities.IEntity<TId>
    {
        Task<TEntity> Get(TId id, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken = default);
        Task<TId> Add(TEntity newEntity, CancellationToken cancellationToken = default);
        Task Update(TEntity updatedEntity, CancellationToken cancellationToken = default);
        Task Delete(TId id, CancellationToken cancellationToken = default);
    }
}