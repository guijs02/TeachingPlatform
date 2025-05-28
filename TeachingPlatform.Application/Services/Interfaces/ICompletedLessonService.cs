using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.InputModels;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ICompletedLessonService
    {
        Task<Response<bool>> FinishLessonAsync(FinishLessonInputModel lesson, Guid studentId);
    }
}
