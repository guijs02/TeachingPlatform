namespace TeachingPlatform.Domain.Entities
{
    public class User
    {
        public User(string userName, string password, EUserRole role)
        {
            UserName = userName;
            Password = password;
            TypeOfUser = role;

            Validate();
        }
        public User(Guid id, string userName, string password, List<Enrollment> enrollments, EUserRole role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            TypeOfUser = role;
            Enrollments = enrollments;

            Validate();
        }

        public Guid Id { get; set; }
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();


        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
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
