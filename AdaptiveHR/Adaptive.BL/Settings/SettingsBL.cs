using AdaptiveHR.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.Settings
{
    public class SettingsBL
    {

        private IConfiguration _configuration;
        public SettingsBL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppSettings LoadSettings()
        {
            try
            {
                AppSettings appSettings = new AppSettings();
                appSettings.Secret = _configuration["Secret"];
                appSettings.Timeout = Convert.ToInt32(_configuration["Timeout"]);
                appSettings.Issuer = _configuration["Issuer"];
                appSettings.Audience = _configuration["Audience"];
                appSettings.SMTP = _configuration["SMTP"];
                appSettings.Email = _configuration["Email"];
                appSettings.Password = _configuration["Password"];
                appSettings.Port = Convert.ToInt32(_configuration["Port"]);
                appSettings.UseSSL = Convert.ToBoolean(_configuration["UseSSL"]);
                appSettings.Salt = _configuration["Salt"];

                return appSettings;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
