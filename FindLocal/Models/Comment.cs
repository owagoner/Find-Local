using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLocal.Models
{
    public class Comment
    {
        public long id { get; set; }
        public string text { get; set; }
        public long entityId { get; set; }
        public long timestamp { get; set; }
        public DateTime date {
            get {
                if (timestamp != 0) {
                    return fromEpochTime(timestamp);
                }
                return DateTime.Now;
            } set { } }
        public string ipAddress { get; set; }
        public string username { get; set; }
        public Business business { get; set; }

        private DateTime fromEpochTime(long epoch)
        {
            var ep = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return ep.AddSeconds(epoch/1000);
        }
    }

    
}