using MarketoApiLibrary.Common.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    /*{
        "type": "Image",
        "id": 29514,
        "name": "LATAM"
      }*/
    public class FolderResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("accessZoneId")]
        public int AccessZoneId { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("folderType")]
        public string FolderType { get; set; }
        [JsonProperty("folderId")]
        public FileFolder FolderId { get; set; }
        [JsonProperty("parent")]
        public FileFolder Parent { get; set; }
        [JsonProperty("isArchive")]
        public bool IsArchive { get; set; }
        [JsonProperty("isSystem")]
        public string IsSystem { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }
    }
}