namespace TeachingPlatform.Api.Common
{
    public static class Endpoints
    {
        #region User
        public const string CreateUser = "register";
        public const string LoginUser = "login";
        #endregion

        #region Course
        public const string CreateCourse = "create-course";
        public const string FinishClass = "finish-class";
        #endregion

        #region Enrollment
        public const string CreateEnrollment = "create-enrollment";
        #endregion
    }
}
