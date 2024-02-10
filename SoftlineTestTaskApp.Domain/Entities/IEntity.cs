namespace SoftlineTestTaskApp.Domain.Entities
{
    public class IEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}