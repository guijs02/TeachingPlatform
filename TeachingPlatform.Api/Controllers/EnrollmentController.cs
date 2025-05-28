using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TeachingPlatform.Api.Common;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        public readonly IEnrollCreateService _enrollService;

        public EnrollmentController(IEnrollCreateService enrollService)
        {
            _enrollService = enrollService;
        }

        [HttpPost(Endpoints.CreateEnrollment)]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> Create(EnrollmentInputModel enrollViewModel)
        {
            try
            {
                var userId = UserInput.GetUserId(User);
                enrollViewModel.StudentId = userId;

                var result = await _enrollService.Create(enrollViewModel);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

    }
}
