using Microsoft.EntityFrameworkCore;
using SoftlineTestTaskApp.Domain.Entities;
using SoftlineTestTaskApp.Domain.Exceptions;
using SoftlineTestTaskApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftlineTestTaskApp.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<Guid> Add(Task newTask, CancellationToken cancellationToken = default)
        {
            var statusExists = await _context.Statuses.AnyAsync(s => s.Id == newTask.StatusId, cancellationToken);

            if (!statusExists)
            {
                throw new EntityNotFoundException(typeof(Status), nameof(Status.Id));
            }

            var result = await _context.Tasks.AddAsync(newTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
        public async System.Threading.Tasks.Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var taskToDelete = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async System.Threading.Tasks.Task<Task> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
        public async System.Threading.Tasks.Task<ICollection<Task>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }
        public async System.Threading.Tasks.Task Update(Task updatedTask, CancellationToken cancellationToken = default)
        {
            var taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == updatedTask.Id, cancellationToken);

            if(taskToUpdate == null)
            {
                throw new EntityNotFoundException(typeof(Task), nameof(Task.Id));
            }

            var statusExists = await _context.Statuses.AnyAsync(s => s.Id == updatedTask.StatusId, cancellationToken);

            if (!statusExists)
            {
                throw new EntityNotFoundException(typeof(Status), nameof(Status.Id));
            }

            taskToUpdate.StatusId = updatedTask.StatusId;
            taskToUpdate.Name = updatedTask.Name;
            taskToUpdate.Description = updatedTask.Description;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}