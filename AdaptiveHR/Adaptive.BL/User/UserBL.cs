using Adaptive.Models.Entities;
using AdaptiveHR.Adaptive.BL.Settings;
using AdaptiveHR.Model;
using AdaptiveHR.Util.Communication;
using AdaptiveHR.Util.Encryption;
using AutoMapper;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public class UserBL : IUserBL
    {
        private AdaptiveHRContext _dbcontext;
        private MailSender _mailSender;
        private AppSettings appSettings;
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

                string Encpassword = RIJEncrypt.Encrypt(password, appSettings.Salt);

                var user = _dbcontext.Users.SingleOrDefault(x => x.Username == username && x.Password == Encpassword);
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
                    catch(Exception ex )
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

        public Task<GlobalResponseDTO> ConfirmRegistration(string guid)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> CreateUser(UserCreationDTO userCreationDTO)
        {
            try
            {
                //Check if theres an existing Username

                if (_dbcontext.Users.Where(c => c.Username == userCreationDTO.UserName).Any())
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Username must be unique" };
                }
                if (_dbcontext.Users.Where(c => c.Email == userCreationDTO.Email).Any())
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Email already in use." };
                }

                string input = userCreationDTO.Password;
                string password = RIJEncrypt.Encrypt(input, appSettings.Salt);
                
                var hasSymbols = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

                if (!hasSymbols.IsMatch(input))
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Password not acceptable" };
                }

                using (var transaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {

                        var data = Mapper.Map<UserCreationDTO, Users>(userCreationDTO);
                        data.Password = password;
                        _dbcontext.Entry(data).State = EntityState.Added;
                        await _dbcontext.SaveChangesAsync();
                        transaction.Commit();
                        //Send confirmation email
                        string key = string.Concat(data.Id, "-", DateTime.UtcNow);
                        string encid = RIJEncrypt.Encrypt(key, appSettings.Salt);

                        string url = Path.Combine(appSettings.ClientURL, key);

                        var htmlTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "Email", "confirmation.html");


                        htmlTemplate = File.ReadAllText(htmlTemplate);
                        htmlTemplate = htmlTemplate.Replace("{link}", url);

                        EmailModel email = new EmailModel();
                        email.From = appSettings.Email;
                        email.Recipients = data.Email;
                        email.Body = htmlTemplate;
                        email.Subject = "Your Adaptive Confirmation Link";



                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new GlobalResponseDTO() { IsSuccess = false, Message = "Server processes error" };
                        throw;
                    }

                   
                }
              
                


                return new GlobalResponseDTO() { IsSuccess = true, Message = "User was created" };


            }
            catch (Exception)
            {

                return new GlobalResponseDTO() { IsSuccess = false, Message = "Server processes error" };
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

                bool existing = _dbcontext.Users.Where(c => c.Username == Username).Any();

                if (existing)
                {

                    var user = _dbcontext.Users.Where(c => c.Username == Username).SingleOrDefault();
                    string key = string.Concat(user.Id, "-", DateTime.UtcNow);

                    string encId = RIJEncrypt.Encrypt(key, appSettings.Salt);

                    string url = Path.Combine(appSettings.ClientURL, encId);

                    var htmlTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "Email", "forgotpassword.html");


                    htmlTemplate = File.ReadAllText(htmlTemplate);
                    htmlTemplate = htmlTemplate.Replace("{link}", url);

                    EmailModel email = new EmailModel();
                    email.From = appSettings.Email;
                    email.Recipients = user.Email;
                    email.Body = htmlTemplate;
                    email.Subject = "Your Adaptive Reset Link";



                    return await _mailSender.Send(email);
                }
                else
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Username not exist" };
                }

               
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
        }

        public async Task<GlobalResponseDTO> ForgotUser(string email)
        {
            try
            {
                bool existing = _dbcontext.Users.Where(c => c.Email == email).Any();

                if (existing)
                {
                    string Username = _dbcontext.Users.Where(c => c.Email == email).Select(c => c.Username).SingleOrDefault().ToString();
                    


                    var htmlTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "Email", "forgotusername.html");


                    htmlTemplate = File.ReadAllText(htmlTemplate);
                    htmlTemplate = htmlTemplate.Replace("{UserName}", Username);

                    EmailModel emailmodel = new EmailModel();
                    emailmodel.From = appSettings.Email;
                    emailmodel.Recipients = email;
                    emailmodel.Body = htmlTemplate;
                    emailmodel.Subject = "Your Adaptive Username";

                    return await _mailSender.Send(emailmodel);
                }
                else
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Username not exist" };
                }


            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }

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

        public async Task<GlobalResponseDTO> ResetPassword(string guid,string password)
        {
            try
            {
                //Check guid authenticity
                string decguid = RIJEncrypt.Decrypt(guid, appSettings.Salt);
                int id = Convert.ToInt32(decguid.Substring(0, decguid.IndexOf('-')));
                DateTime resetDate = Convert.ToDateTime(decguid.Substring(decguid.LastIndexOf('-') + 1));

                if ((DateTime.UtcNow - resetDate).TotalMinutes > appSettings.ResetTimeout)
                {
                    return new GlobalResponseDTO() { IsSuccess = false, Message = "Reset token is expired" };
                }
                else
                {
                    //Encrypt password
                    password = RIJEncrypt.Encrypt(password, appSettings.Salt);


                    using (var transaction = _dbcontext.Database.BeginTransaction())
                    {
                        try
                        {

                            var data = _dbcontext.Users.Where(c => c.Id == id).SingleOrDefault();
                            data.Password = password;
                            _dbcontext.Entry(data).State = EntityState.Modified;
                            await _dbcontext.SaveChangesAsync();
                            transaction.Commit();

                        }
                        catch
                        {
                            transaction.Rollback();
                            return new GlobalResponseDTO() { IsSuccess = false, Message = "Server processes error" };
                            throw;
                        }

                        return new GlobalResponseDTO() { IsSuccess = true, Message = "Password was reset." };
                    }
                }


            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw new Exception("Server processes error", ex);
            }
                
        }
    }
}
