using FindLocal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace FindLocal.Services
{
    public class MediaService
    {
        private const string baseUrl = "https://mediaservice.cfapps.io";

        public Media getMediaById(int id)
        {
            string route = "/api/media/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return JsonConvert.DeserializeObject<Media>(response);
        }
        public List<Media> getMediaByBusinessId(int id)
        {
            string route = "/api/media/businessId/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return JsonConvert.DeserializeObject<List<Media>>(response);
        }
        public string getFeaturedByBusinessId(int id)
        {
            string route = "/api/media/feature/businessId/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return response;
        }
        public List<string> getAllImagesByBusinessId(int id)
        {
            string route = "/api/media/all/businessId/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return JsonConvert.DeserializeObject<List<string>>(response);
        }
        public Media saveMedia(Media m)
        {
            string route = "api/address";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + route);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(m);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Media>(result);
                }
            }
        }
    }
}