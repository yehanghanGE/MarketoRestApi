using System;
using Newtonsoft.Json;
using MarketoRestApiLibrary.Provider;
using MarketoRestApiLibrary.Service;
using Newtonsoft.Json.Linq;
using MarketoRestApiLibrary;
using MarketoApiLibrary.Service;
using MarketoRestApiLibrary.Request;
using MarketoApiLibrary;

namespace MarketoApiConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var apiConfig = ConfigurationProvider.LoadConfig();
            var host = apiConfig.Host;
            var clientId = apiConfig.ClientId;
            var clientSecret = apiConfig.ClientSecret;

            var client = new MarketoClient(host, clientId, clientSecret);

            var filesResult = client.GetSmartList().Result;
            var jsonFormatted = JToken.Parse(filesResult).ToString(Formatting.Indented);
            Console.WriteLine(jsonFormatted);
            Console.ReadKey();
        }
    }
}
