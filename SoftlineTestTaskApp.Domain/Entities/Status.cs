namespace SoftlineTestTaskApp.Domain.Entities
{
    public sealed class Status : IEntity<int>
    {
        public string Name { get; set; }
    }
}