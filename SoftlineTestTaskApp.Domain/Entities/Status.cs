namespace SoftlineTestTaskApp.Domain.Entities
{
    public sealed class Status : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}