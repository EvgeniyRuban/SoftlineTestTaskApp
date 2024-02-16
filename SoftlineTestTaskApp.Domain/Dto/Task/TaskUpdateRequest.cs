using System;

namespace SoftlineTestTaskApp.Domain.Dto
{
    public class TaskUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}