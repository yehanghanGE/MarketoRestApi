using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Common.Model
{
    public class FileFolder : IFileFolder
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}