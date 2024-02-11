using SoftlineTestTaskApp.Domain.Dto;
using SoftlineTestTaskApp.Domain.Entities;
using SoftlineTestTaskApp.Domain.Repositories;
using SoftlineTestTaskApp.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.Services.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<int> Add(StatusCreateRequest statusCreateRequest, CancellationToken cancellationToken = default)
        {
            var statusToCreate = new Status
            {
                Name = statusCreateRequest.Name,
            };

            return await _statusRepository.Add(statusToCreate, cancellationToken);
        }
        public async System.Threading.Tasks.Task Delete(int id, CancellationToken cancellationToken = default)
        {
            await _statusRepository.Delete(id, cancellationToken);
        }
        public async Task<StatusDto> Get(int id, CancellationToken cancellationToken = default)
        {
            var status = await _statusRepository.Get(id, cancellationToken);

            return new StatusDto
            {
                Id = status.Id,
                Name = status.Name,
            };
        }
        public async Task<ICollection<StatusDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var statuses = await _statusRepository.GetAll(cancellationToken);
            var statusesDto = new List<StatusDto>(statuses.Count);
            foreach (var status in statusesDto)
            {
                statusesDto.Add(new StatusDto
                {
                    Id = status.Id,
                    Name = status.Name,
                });
            }

            return statusesDto;
        }
        public async System.Threading.Tasks.Task Update(StatusUpdateRequest statusUpdateRequest, CancellationToken cancellationToken = default)
        {
            var statusToUpdate = new Status
            {
                Id = statusUpdateRequest.Id,
                Name = statusUpdateRequest.Name
            };
            await _statusRepository.Update(statusToUpdate, cancellationToken);
        }
    }
}