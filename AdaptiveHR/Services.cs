using AdaptiveHR.Adaptive.BL.PDS;
using AdaptiveHR.Adaptive.BL.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR
{
    public static class Services
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IPDSBL, PDSBL>();
            services.AddScoped<IUserBL, UserBL>();
        }
    }
}
