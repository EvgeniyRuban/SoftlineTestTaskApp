using System.ComponentModel.DataAnnotations;

namespace SoftlineTestTaskApp.Domain.Entities
{
    public sealed class Status : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}