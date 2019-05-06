using AdaptiveHR.Adaptive.BL.Settings;
using AdaptiveHR.Model;
using Microsoft.Extensions.Configuration;
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
        private AppSettings appSettings = new AppSettings();
        public MailSender(IConfiguration configuration, SettingsBL settingsBL)
        {
            appSettings = settingsBL.LoadSettings();
        }
        public async Task<GlobalResponseDTO> Send(EmailModel email)
        {
            try
            {
                var client = new SmtpClient(appSettings.SMTP, appSettings.Port)
                {
                    Credentials = new NetworkCredential(appSettings.Email, appSettings.Password),
                    EnableSsl = true,
                    
                };

                //client.Send(email.From, email.Recipients, email.Subject, email.Body);
                MailMessage mail = new MailMessage(email.From, email.Recipients, email.Subject, email.Body);
                mail.IsBodyHtml = true;

                client.Send(mail);

                return new GlobalResponseDTO() { IsSuccess = true, Message = "Email sent." };



            }
            catch (Exception)
            {
                return new GlobalResponseDTO() { IsSuccess = false, Message = "Server error" };
            }
        }
    }
}
