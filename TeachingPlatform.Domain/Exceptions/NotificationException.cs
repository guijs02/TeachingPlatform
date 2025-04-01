using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Domain.Exceptions
{
    public class NotificationException(string message) : Exception(message)
    {
    }
}
