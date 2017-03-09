using FindLocal.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FindLocal.Services
{
    public class CommentService
    {

        private const string baseUrl = "https://commentservice2.cfapps.io";
        private BusinessService bs = new BusinessService();
        public List<Comment> getLatestNComments(int n) {
            string route = "/api/comment/latest/" + n;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            List<Comment> c = JsonConvert.DeserializeObject<List<Comment>>(response);
            foreach (Comment comment in c) {
                comment.business = bs.getBusinessById((int)comment.entityId);
            }
            return c;

        }

        public List<Comment> getCommentsByBusinessId(long id) {
            string route = "/api/comment/entity/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);
            List<Comment> c = JsonConvert.DeserializeObject<List<Comment>>(response);
            return c;
        }

        public Comment getCommentById(long id)
        {
            string route = "/api/comment/" + id;
            WebClient wc = new WebClient();
            var response = wc.DownloadString(baseUrl + route);            
            Comment c = JsonConvert.DeserializeObject<Comment>(response);
            return c;
        }

        public Comment saveComment(Comment c) {
            string route = "api/comment";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + route);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(c);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Comment>(result);
                }
            }
        }

        public Comment deleteComment(Comment c) {
            return null;
        }

    }
}