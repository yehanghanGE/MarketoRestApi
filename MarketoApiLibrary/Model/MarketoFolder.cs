using Newtonsoft.Json;

namespace MarketoRestApiLibrary.Model
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
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}