using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Invitation
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Date { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendSms { get; set; }
        public bool? Confirmed { get; set; }
    }
}
