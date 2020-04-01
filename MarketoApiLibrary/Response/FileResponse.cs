using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Response
{
    /*{
      "id": 518799,
      "size": 1786900,
      "mimeType": "image/jpeg",
      "url": "http://landing-uat.gehealthcare.com/rs/gehealthcaresandbox5/images/LAS+500_08A4474.jpg",
      "folder": {
        "type": "Image",
        "id": 29514,
        "name": "LATAM"
      },
      "name": "LAS 500_08A4474.jpg",
      "description": null,
      "createdAt": "2017-09-06T16:48:48Z+0000",
      "updatedAt": "2017-09-06T16:48:48Z+0000"
    }*/


    public class FileResponse : IFileResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("folder")]
        public FileFolder Folder { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}