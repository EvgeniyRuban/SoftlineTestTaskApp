using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftlineTestTaskApp.Domain.Entities
{
    public sealed class Task : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}