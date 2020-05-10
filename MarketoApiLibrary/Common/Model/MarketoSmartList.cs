using MarketoApiLibrary.Asset.Folders.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Common.Model
{
    public class MarketoSmartList
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("folder")]
        public FolderResponse MarketoFolder { get; set; }
        [JsonProperty("computedUrl")]
        public string ComputedUrl { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}