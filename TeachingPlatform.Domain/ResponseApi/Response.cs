using System.Text.Json.Serialization;

namespace TeachingPlatform.Domain.ResponseApi
{
    public class Response<TData>
    {
        private int _statusCode = 200;
        public Response(TData? data, int statusCode = 200, string? message = null)
        {
            _statusCode = statusCode;
            Message = message;
            Data = data;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _statusCode is >= 200 and <= 299;
    }
}
