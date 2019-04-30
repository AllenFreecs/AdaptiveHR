using Adaptive.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Adaptive.BL.User
{
    public interface IUserBL
    {
        Users Authenticate(string username, string password);
        IEnumerable<Users> GetAll();
    }
}
