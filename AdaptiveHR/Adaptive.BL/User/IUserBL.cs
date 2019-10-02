using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public interface IUserBL
    {
        Task<GlobalResponseDTO> Authenticate(string username, string password, HttpResponse response);
        string ReIssuetoken(string claimID, string roleID , HttpResponse response);
        Task<bool> ForgeryDetected(string token , int userID);
        Task<GlobalResponseDTO> ForgotPassword(string Username);
        Task<GlobalResponseDTO> ForgotUser(string email);
        Task<GlobalResponseDTO> CreateUser(UserCreationDTO userCreationDTO);
        Task<GlobalResponseDTO> ResetPassword(string guid,string password);
        Task<GlobalResponseDTO> ConfirmRegistration(string guid);

    }
}
