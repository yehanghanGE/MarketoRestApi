using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListResponse
    {
        [JsonProperty("id")] 
        public int Id { get; set; }
        [JsonProperty("name")] 
        public string Name { get; set; }
        [JsonProperty("description")] 
        public string Description { get; set; }
        [JsonProperty("createdAt")] 
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")] 
        public string UpdatedAt { get; set; }
        [JsonProperty("url")] 
        public string Url { get; set; }
        [JsonProperty("folder")]
        public Folder Folder { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }
    }
}
