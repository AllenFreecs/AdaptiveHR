using Adaptive.Models.Entities;
using AdaptiveHR.Adaptive.BL.Settings;
using AdaptiveHR.Model;
using AdaptiveHR.Util.Communication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public class UserBL : IUserBL
    {
        private AdaptiveHRContext _dbcontext;
        private MailSender _mailSender;
        private AppSettings appSettings = new AppSettings();
        public UserBL(AdaptiveHRContext adaptiveHRContext , IConfiguration configuration , SettingsBL settingsBL , MailSender mailSender)
        {
            _dbcontext = adaptiveHRContext;
            appSettings = settingsBL.LoadSettings();
            _mailSender = mailSender;
        }
    
        public UserInfo Authenticate(string username, string password)
        {
            try
            {
                
                var user = _dbcontext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
                // return null if user not found
                if (user == null)
                    return null;
                var Token = ReIssuetoken(user.Id.ToString(), user.IdUserGroup.ToString());
                user.Token = Token;
                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbcontext.Entry(user).State = EntityState.Modified;
                        _dbcontext.SaveChanges();
                        transaction.Commit();

                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }



                return new UserInfo() { token = Token , email = user.Email , name = string.Concat(user.FirstName," ", user.LastName)} ;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }

        }

        public bool ForgeryDetected(string token, int userID)
        {
            try
            {
                token = token.Replace("Bearer ", string.Empty);

                var user = _dbcontext.Users.SingleOrDefault(x => x.Id == userID);

                if (user.Token != token)
                {
                    //Forgery Detected
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> ForgotPassword(string Username)
        {
            try
            {

                var htmlTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "Email", "forgotpassword.html");
                htmlTemplate = File.ReadAllText(htmlTemplate);
                EmailModel email = new EmailModel();
                email.From = appSettings.Email;
                email.Recipients = Username;
                email.Body = htmlTemplate;
                email.Subject = "test subject";

                

                return await _mailSender.Send(email);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> ForgotUser(string email)
        {
            throw new NotImplementedException();
        }

        public string ReIssuetoken(string claimID , string RoleID)
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
                    new Claim(ClaimTypes.Name, claimID),
                     new Claim(ClaimTypes.Role, RoleID)
                    }),
                    Issuer = appSettings.Issuer,
                    Audience = appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(appSettings.Timeout),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var newtoken =  tokenHandler.WriteToken(token);

                return newtoken;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }
    }
}
