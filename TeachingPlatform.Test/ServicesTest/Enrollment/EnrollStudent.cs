using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.User.Create;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Test.ServicesTest.Enrollment
{
    public class EnrollStudent
    {
        //private readonly EnrolStudentService _service;
        //private readonly Mock<IStudentRepository> _repository;
        //public EnrollStudent()
        //{
        //    _repository = new Mock<IStudentRepository>();
        //    _service = new(_repository.Object);
        //}

        //[Fact]
        //public async Task EnrollStudentWithSuccess()
        //{
        //    var user = new EnrollmentViewModel
        //    {
        //        StudentId = Guid.NewGuid(),
        //        CourseId = Guid.NewGuid(),
        //        CreateAt = DateTime.Now,

        //    };


        //    var resultExpected = _repository.Setup(s => s.Enroll(It.IsAny<Domain.Entities.Enrollment>())).ReturnsAsync(true);

        //    var result = await _service.Enroll(user);

        //    Assert.True(result?.IsSuccess);
        //}

        //[Fact]
        //public async Task CreateUserShouldBeFalse()
        //{
        //    UserCreateInputModel? user = null;

        //    var resultExpected = _repository.Setup(s => s.Create(It.IsAny<Domain.Entities.User>())).ReturnsAsync(false);

        //    var result = await _service.Create(user);

        //    Assert.False(result?.IsSuccess);
        //}

    }
}
