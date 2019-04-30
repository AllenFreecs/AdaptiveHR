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
        }

        public string Authenticate(string username, string password)
        {
            try
            {
                var user = _dbcontext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;

                return user.Token;
            }
            catch (Exception)
            {

                throw;
            } 
             
        }

        public string Checkheartbeat()
        {
            throw new NotImplementedException();
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
    }
}
