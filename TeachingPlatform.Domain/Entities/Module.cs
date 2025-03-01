namespace TeachingPlatform.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CourseId { get; set; }
        public List<Lesson> Lessons { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
