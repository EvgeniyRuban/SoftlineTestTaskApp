namespace SoftlineTestTaskApp.Domain.Dto
{
    public class TaskCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}