using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marketo.ApiLibrary.Mis.Utility
{
    public class FileDownloader
    {
        public static Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception)
            {
                return null;
            }

            return image;
        }
        //TODO
        public static async Task HttpGetForLargeFiley(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    string fileToWriteTo = Path.GetTempFileName();
                    using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
            }
        }
        public static void DownFile(string url, string savePath)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri(url), savePath);
        }

        public static Task DownFileAsync(string url, string savePath)
        {
            WebClient webClient = new WebClient();
            Task task = webClient.DownloadFileTaskAsync(new Uri(url), savePath);
            return task;
        }
    }
}
