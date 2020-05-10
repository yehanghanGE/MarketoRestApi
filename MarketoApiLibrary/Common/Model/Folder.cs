﻿using Newtonsoft.Json;

namespace MarketoApiLibrary.Common.Model
{
    public class Folder
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}