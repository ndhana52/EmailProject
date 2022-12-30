using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailProject.Models
{
    public class SmtpConfigModel
    {
        public string SenderAddress { get; set;}
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int port { get; set; }
        public bool EnableSSL { get; set; }
        public  bool UserDefaultCredential { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
