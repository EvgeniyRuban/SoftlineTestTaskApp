using SoftlineTestTaskApp.Domain.Entities;
using System;

namespace SoftlineTestTaskApp.Domain.Repositories
{
    public interface ITaskRepository : ICrudRepository<Task, Guid>
    {
    }
}