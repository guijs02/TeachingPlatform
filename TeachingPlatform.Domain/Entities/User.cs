using TeachingPlatform.Domain.Exceptions;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class User : Entity
    {
        public User(Guid id, string userName, string password, EUserRole role) : base(id)
        {
            UserName = userName;
            Password = password;
            TypeOfUser = role;

            Validate();
        }
     
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();


        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new UserValidator());

            if (Notification.HasErrors())
            {
                throw new DomainException(Notification.GetErrors());
            }
        }
    }
    public enum EUserRole
    {
        TEACHER = 1,
        STUDENT = 2,
    }
}
