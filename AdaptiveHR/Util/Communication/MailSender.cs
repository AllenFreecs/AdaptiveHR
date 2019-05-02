using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdaptiveHR.Util.Communication
{
    public class MailSender
    {
        public MailSender()
        {

        }
        public void Send(string email)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("myusername@gmail.com", "mypwd"),
                    EnableSsl = true
                };
                client.Send("myusername@gmail.com", "myusername@gmail.com", "test", "testbody");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
