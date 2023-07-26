using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class SMTP
    {
        public string SMTPServer;
        public string SMTPEmail;
        public int Port;
        public string UserName;
        public string Password;
        public string SenderEmail;
        public bool SSLEnable;
        public bool BlackListEmail;
        public int EmailFrequency;

    }
}
