using System.Text.Json.Serialization;

namespace TeachingPlatform.Application.InputModels
{
    public class EnrollmentInputModel
    {
        public Guid CourseId { get; set; }
        [JsonIgnore]
        public Guid StudentId { get; set; }
    }
}
