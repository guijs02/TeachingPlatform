using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Exceptions;

namespace TeachingPlatform.Domain.ValueObjects
{
    public record class StudentId 
    {
        public Guid Value { get; }
        public StudentId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("StudentId cannot be empty.");
            }

            Value = value;
        }
        public static implicit operator StudentId(Guid studentId) => new(studentId);
    }
}
