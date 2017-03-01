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
    public class BusinessService
    {
        private const string baseUrl = "https://businessservice.cfapps.io";

        public List<Business> getRandomNBusinesses(int n)
        {
            string route = "/api/business/random/" + n;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            List<Business> b = JsonConvert.DeserializeObject<List<Business>>(response);
            return b;
        }
        public List<Business> getBusinessesByType(long i)
        {
            string route = "/api/business/type/" + i;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            List<Business> b = JsonConvert.DeserializeObject<List<Business>>(response);
            return b;
        }
        public Business getBusinessById(int n)
        {
            string route = "/api/business/" + n;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            Business b = JsonConvert.DeserializeObject<Business>(response);
            return b;
        }
        public List<Business> getBusinessesByName(string name)
        {
            string route = "/api/business/byname";
            WebClient wc = new WebClient();
            wc.QueryString.Add("byname", name);
            var response = wc.DownloadString(baseUrl + route);
            List<Business> b = JsonConvert.DeserializeObject<List<Business>>(response);
            return b;
        }

        public Business saveBusiness(Business b)
        {
            string route = "api/business";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + route);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(b);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Business>(result);
                }
            }
        }
    }
}