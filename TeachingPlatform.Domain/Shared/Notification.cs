using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Domain.Shared
{
    public class NotificationErrorProps(string context, string message)
    {
        public string Context { get; set; } = context;
        public string Message { get; set; } = message;
    }

    public class Notification
    {
        private List<NotificationErrorProps> Errors = [];

        public void AddError(string context, string message)
        {
            Errors.Add(new NotificationErrorProps(context, message));
        }  
       
        public string GetMessages(string? context)
        {
            string messages = string.Empty;

            Errors.ForEach(e =>
            {
                if (e.Context == context || context == null)
                {
                    messages += $"{e.Context}: {e.Message}, ";
                }
            });
            
            return messages;
        }
        public bool HasErrors()
            => Errors.Count != 0;

        public List<NotificationErrorProps> GetErrors()
         => Errors;
    }
}
