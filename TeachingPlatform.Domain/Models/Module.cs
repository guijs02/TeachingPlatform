namespace TeachingPlatform.Domain.Models
{
    public class Module
    {
        public int Id { get; set; }
        public List<Lesson> Lessons { get; set; } = null!;
        public virtual Rating Rating { get; set; } = null!;
        public int RatingId { get; set; }
    }
}
