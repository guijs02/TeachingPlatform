﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
