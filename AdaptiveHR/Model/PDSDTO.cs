using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class PDSDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string SessionId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string HomeAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string CivilStatus { get; set; }
        public string EmailAddress { get; set; }
        public int? MobileNumber { get; set; }
        public int? Sss { get; set; }
        public int? Phic { get; set; }
        public int? Tin { get; set; }
        public int? IdJob { get; set; }
        public int? IdEducation { get; set; }
        public int? IdAwards { get; set; }
        public int? IdSeminar { get; set; }
        public decimal? CurrentSalary { get; set; }
        public decimal? AskingSalary { get; set; }
        public bool? ContactPreviousEmployer { get; set; }
    }
}
