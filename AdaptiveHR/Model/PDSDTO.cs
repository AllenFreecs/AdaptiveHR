using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class PDSDTO
    {
        public int Id { get; set; }
        public string SessionID { get; set; }
        public string Image { get; set; }
        public int? ID_Docs { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
        public string HomeAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string CivilStatus { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int? SSS { get; set; }
        public int? PHIC { get; set; }
        public int? TIN { get; set; }
        public int? ID_Job { get; set; }
        public int? ID_Education { get; set; }
        public int? ID_Awards { get; set; }
        public int? ID_Seminar { get; set; }
        public bool ContactPreviousEmployer { get; set; }

    }
}
