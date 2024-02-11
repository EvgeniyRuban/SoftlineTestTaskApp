using SoftlineTestTaskApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.Domain.Repositories
{
    public interface ICrudRepository<TEntity, TKey>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        Task<TEntity> Get(TKey id, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> GetAll(CancellationToken cancellationToken = default);
        Task<TKey> Add(TEntity newEntity, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task Update(TEntity updatedEntity, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task Delete(TKey id, CancellationToken cancellationToken = default);
    }
}