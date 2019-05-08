using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsConfirmed { get; set; }
        public int? IdUserGroup { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
        public string Guid { get; set; }
        public string Token { get; set; }
    }
}
