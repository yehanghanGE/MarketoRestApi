using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Common.Model
{
    public class Folder
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}