using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Shared;

namespace TeachingPlatform.Test.EntitiesTest
{
    public class NotificationTest
    {
        [Fact]
        public void AddErrorWithSuccess()
        {
            string error = "user: Erro 1, user: Erro 2, ";

            var notification = new Notification();
            notification.AddError("user", "Erro 1");
            notification.AddError("user", "Erro 2");

            Assert.Equal(2, notification.GetErrors().Count);
            Assert.True(notification.HasErrors());
            Assert.Equal(error, notification.GetMessages("user"));
        }
    }
}
