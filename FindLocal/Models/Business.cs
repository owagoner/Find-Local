using FindLocal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLocal.Models
{
    public class Business
    {
        public long id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string phoneNumber { get; set; }
        public long businessTypeId { get; set; }
        public string description { get; set; }
        public List<Comment> comments {
            get {
                CommentService cs = new CommentService();
                return cs.getCommentsByBusinessId(this.id);
            }
        set { }
        }
        public Media media { get; set; }
        //get {
        //    MediaService ms = new MediaService();
        //    return ms.getMediaByBusinessId((int)this.id).FirstOrDefault();
        //} set { } }
        public Address address { get; set; }
        public string twitterHandle { get; set; }
        public string businessHours { get; set; }
    }
}