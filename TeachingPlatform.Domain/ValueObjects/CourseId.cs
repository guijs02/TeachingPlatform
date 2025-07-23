using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Exceptions;

namespace TeachingPlatform.Domain.ValueObjects
{
    public class CourseId
    {
        public Guid Value { get; }
        public CourseId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("CourseId cannot be empty.");
            }

            Value = value;
        }

        public static bool operator ==(Guid id, CourseId courseId) => id.Equals(courseId.Value);
        public static bool operator !=(Guid id, CourseId courseId) => id.Equals(courseId.Value);

        public static implicit operator CourseId(Guid courseId) => new(courseId);

        public override bool Equals(object obj)
        {
            if (obj is CourseId courseId)
            {
                return Value.Equals(courseId.Value);
            }

            if (obj is Guid guid)
            {
                return Value.Equals(guid);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
