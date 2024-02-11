using SoftlineTestTaskApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftlineTestTaskApp.Domain.Services
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task<Guid> Add(TaskCreateRequest taskCreateRequest, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task<TaskDto> Get(TaskGetRequest taskGetRequest, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task<ICollection<TaskDto>> GetAll(CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task Update(TaskUpdateRequest taskUpdateRequest, CancellationToken cancellationToken = default);
        System.Threading.Tasks.Task Delete(TaskDeleteRequest taskDeleteRequest, CancellationToken cancellationToken = default);
    }
}