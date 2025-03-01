namespace TeachingPlatform.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();

    }
    public enum EUserRole
    {
        TEACHER = 1,
        STUDENT = 2,
    }
}
