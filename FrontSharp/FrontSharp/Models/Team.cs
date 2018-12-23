using System.Collections.Generic;

namespace FrontSharp.Models
{
    public class Team : BaseResponseBody
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Inbox> inboxes { get; set; }
        public List<Teammate> members { get; set; }
    }
}