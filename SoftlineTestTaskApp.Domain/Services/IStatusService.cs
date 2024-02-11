using SoftlineTestTaskApp.Domain.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.Domain.Services
{
    public interface IStatusService
    {
        Task<int> Add(StatusCreateRequest statusCreateRequest, CancellationToken cancellationToken = default);
        Task<StatusDto> Get(StatusGetRequest statusGetRequest, CancellationToken cancellationToken = default);
        Task<ICollection<StatusDto>> GetAll(CancellationToken cancellationToken = default);
        Task Update(StatusUpdateRequest statusUpdateRequest, CancellationToken cancellationToken = default);
        Task Delete(StatusDeleteRequest statusDeleteRequest, CancellationToken cancellationToken = default);
    }
}