﻿using Microsoft.EntityFrameworkCore;
using SoftlineTestTaskApp.Domain.Entities;
using SoftlineTestTaskApp.Domain.Exceptions;
using SoftlineTestTaskApp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.DAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationContext _context;

        public StatusRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Status newStatus, CancellationToken cancellationToken = default)
        {
            bool exists = await _context.Statuses.AnyAsync(s => s.Name == newStatus.Name, cancellationToken);

            if (exists)
            {
                throw new EntityAlreadyExistsException(typeof(Status));
            }

            var result = await _context.Statuses.AddAsync(newStatus, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
        public async System.Threading.Tasks.Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Status> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
        public async Task<ICollection<Status>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Statuses.ToListAsync(cancellationToken);
        }
        public async System.Threading.Tasks.Task Update(Status updatedStatus, CancellationToken cancellationToken = default)
        {

            bool newStatusNameIsUsed = await _context.Statuses.AnyAsync(s => 
            s.Id != updatedStatus.Id && 
            s.Name == updatedStatus.Name, cancellationToken);

            if (newStatusNameIsUsed)
            {
                throw new EntityAlreadyExistsException(typeof(Status), nameof(Status.Name));
            }

            var statusToUpdate = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == updatedStatus.Id, cancellationToken);

            statusToUpdate.Name = updatedStatus.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}