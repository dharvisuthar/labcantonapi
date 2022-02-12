using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace labcantonapi.Models
{
    public class EmailData
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Usermessage { get; set; }
        public string Username { get; set; }
        public string Userphone { get; set; }
    }
}