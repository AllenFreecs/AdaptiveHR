using Adaptive.Models.Entities;
using AdaptiveHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public interface IUserBL
    {
        UserInfo Authenticate(string username, string password);
        string ReIssuetoken(string claimID, string roleID);
        bool ForgeryDetected(string token , int userID);
        Task<GlobalResponseDTO> ForgotPassword(string Username);
        Task<GlobalResponseDTO> ForgotUser(string email);
        Task<GlobalResponseDTO> CreateUser(UserCreationDTO userCreationDTO);
        Task<GlobalResponseDTO> ResetPassword(string guid,string password);
        Task<GlobalResponseDTO> ConfirmRegistration(string guid);

    }
}
