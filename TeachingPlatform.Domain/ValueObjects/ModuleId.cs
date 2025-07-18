using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Exceptions;

namespace TeachingPlatform.Domain.ValueObjects
{
    public class ModuleId
    {
        public Guid Value { get; }
        public ModuleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("ModuleId cannot be empty.");
            }

            Value = value;
        }

        public static implicit operator ModuleId(Guid moduleId) => new(moduleId);
    }
}
