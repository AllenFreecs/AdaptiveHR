﻿using Adaptive.Models.Entities;
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
        GlobalResponseDTO ForgotPassword(string Username);
        GlobalResponseDTO ForgotUser(string email);

    }
}
