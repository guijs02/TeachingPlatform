using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IUserLoginService
    {
        Task<Response<string>> Login(UserLoginInputModel userLoginViewModel);
    }
}
