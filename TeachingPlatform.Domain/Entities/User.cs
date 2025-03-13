namespace TeachingPlatform.Domain.Entities
{
    public class User
    {
        public User() { }
        public User(string userName, string password, EUserRole role)
        {
            UserName = userName;
            Password = password;
            TypeOfUser = role;

            Validate();
        }

        public Guid Id { get; set; }
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();


        private void Validate()
        {
            if (!Enum.IsDefined(TypeOfUser))
            {
                throw new InvalidOperationException();
            }
        }
    }
    public enum EUserRole
    {
        TEACHER = 1,
        STUDENT = 2,
    }
}
