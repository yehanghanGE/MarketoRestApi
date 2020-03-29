using Newtonsoft.Json;

namespace MarketoApiLibrary.Model
{
    /*{
        "type": "Image",
        "id": 29514,
        "name": "LATAM"
      }*/
    public class MarketoFolder
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
        public Folder FolderId { get; set; }
        [JsonProperty("parent")]
        public Folder Parent { get; set; }
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

    public class Folder
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}