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
    public class AddressService
    {

        private const string baseUrl = "https://addressservice.cfapps.io";

        public List<Address> getAddressByBusinessId(int id)
        {
            string route = "/api/address/businessId/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return JsonConvert.DeserializeObject<List<Address>>(response);
        }
        public Address getAddressById(int id)
        {
            string route = "/api/address/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            return JsonConvert.DeserializeObject<Address>(response);
        }
        public Address saveAddress(Address a)
        {
            string route = "api/address";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + route);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(a);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Address>(result);
                }
            }
        }
    }
}