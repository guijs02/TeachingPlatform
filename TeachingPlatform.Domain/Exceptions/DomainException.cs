using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Shared;

namespace TeachingPlatform.Domain.Exceptions
{
    public sealed class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
        public DomainException(IEnumerable<NotificationErrorProps> errors) : base(string.Join(",", errors))
        {
        }
        
    }
}
