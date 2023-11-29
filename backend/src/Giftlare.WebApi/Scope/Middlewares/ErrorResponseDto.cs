using Newtonsoft.Json;

namespace Giftlare.WebApi.Scope.Middlewares
{
    public class ErrorResponseDto
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("detail")]
        public string? Detail { get; set; }

        [JsonProperty("instance")]
        public string? Instance { get; set; }

        [JsonProperty("traceId")]
        public string? TraceId { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
