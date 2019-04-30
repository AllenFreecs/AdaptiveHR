using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public class UserBL : IUserBL
    {
        private AdaptiveHRContext _dbcontext;
        private AppSettings appSettings = new AppSettings();
        public UserBL(AdaptiveHRContext adaptiveHRContext , IConfiguration configuration)
        {
            _dbcontext = adaptiveHRContext;
            appSettings.Secret = configuration["Secret"];
            appSettings.Timeout = Convert.ToInt32(configuration["Timeout"]);
        }

        public string Authenticate(string username, string password)
        {
            try
            {
                var user = _dbcontext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
                // return null if user not found
                if (user == null)
                    return null;
                var Token = ReIssuetoken(user.Id.ToString());
                return Token;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<Users> GetAll()
        {
            try
            {
                var users = _dbcontext.Users.ToList();

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ReIssuetoken(string claimID)
        {
            try
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, claimID)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(appSettings.Timeout),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var newtoken =  tokenHandler.WriteToken(token);

                return newtoken;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
