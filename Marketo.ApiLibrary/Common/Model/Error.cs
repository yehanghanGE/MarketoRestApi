using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Common.Model
{
    public class Error : IError
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
