using Newtonsoft.Json;

namespace MarketoApiLibrary.Model
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