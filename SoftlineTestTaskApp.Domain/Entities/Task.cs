using System;

namespace SoftlineTestTaskApp.Domain.Entities
{
    public sealed class Task : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}