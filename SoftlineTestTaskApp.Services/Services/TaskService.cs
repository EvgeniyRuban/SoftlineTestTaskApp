﻿using SoftlineTestTaskApp.Domain.Dto;
using SoftlineTestTaskApp.Domain.Entities;
using SoftlineTestTaskApp.Domain.Exceptions;
using SoftlineTestTaskApp.Domain.Repositories;
using SoftlineTestTaskApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftlineTestTaskApp.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task<Guid> Add(TaskCreateRequest taskCreateRequest, CancellationToken cancellationToken = default)
        {
            var task = new Task
            {
                Name = taskCreateRequest.Name,
                Description = taskCreateRequest.Description,
                StatusId = taskCreateRequest.StatusId,
            };

            return await _taskRepository.Add(task, cancellationToken);
        }
        public async System.Threading.Tasks.Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var taskToDelete = await _taskRepository.Get(id, cancellationToken);

            if(taskToDelete == null)
            {
                throw new EntityNotFoundException(typeof(Task), nameof(Task.Id));
            }

            await _taskRepository.Delete(id, cancellationToken);
        }
        public async System.Threading.Tasks.Task<TaskDto> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var task = await _taskRepository.Get(id, cancellationToken);

            if(task == null)
            {
                throw new EntityNotFoundException(typeof(Task), nameof(Task.Id));
            }

            return new TaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StatusId = task.StatusId,
            };
        }
        public async System.Threading.Tasks.Task<ICollection<TaskDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var tasks = await _taskRepository.GetAll(cancellationToken);
            var tasksDto = new List<TaskDto>(tasks.Count);
            foreach (var task in tasks)
            {
                tasksDto.Add(new TaskDto
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    StatusId = task.StatusId,
                });
            }

            return tasksDto;
        }
        public async System.Threading.Tasks.Task Update(TaskUpdateRequest taskUpdateRequest, CancellationToken cancellationToken = default)
        {
            var taskToUpdate = new Task
            {
                Id = taskUpdateRequest.Id,
                Name = taskUpdateRequest.Name,
                Description = taskUpdateRequest.Description,
                StatusId = taskUpdateRequest.StatusId,
            };

            await _taskRepository.Update(taskToUpdate, cancellationToken);
        }
    }
}