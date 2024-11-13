namespace TeachingPlatform.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TeacherId { get; set; }
        public int StudentId { get; set; } 
        public List<Module> Mudeles { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
    }
}
