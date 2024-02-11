using System.ComponentModel.DataAnnotations;

namespace SoftlineTestTaskApp.Domain.Entities
{
    public interface IEntity<TId> where TId : struct
    {
        [Key]
        TId Id { get; set; }
    }
}