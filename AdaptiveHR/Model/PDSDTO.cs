using System;
using System.ComponentModel.DataAnnotations;


namespace AdaptiveHR.Model
{
    public class PDSDTO
    {
        public int Id { get; set; }
        public string SessionID { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middlename is required")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime? BirthDay { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(300)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Home address is required")]
        [StringLength(300)]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "Current address is required")]
        [StringLength(300)]
        public string CurrentAddress { get; set; }

        [Required(ErrorMessage = "Civil status is required")]
        [StringLength(50)]
        public string CivilStatus { get; set; }

        [EmailAddress(ErrorMessage = "Invalid EmailAddress")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "MobileNumber is required")]
        [StringLength(11, MinimumLength = 11 , ErrorMessage = "This field must be 11 characters")]
        public string MobileNumber { get; set; }
        public int? SSS { get; set; }
        public int? PHIC { get; set; }
        public int? TIN { get; set; }

        [Required(ErrorMessage = "Job is required")]
        public int? ID_Job { get; set; }

        [Required(ErrorMessage = "Education is required")]
        public int? ID_Education { get; set; }

        public int? ID_Awards { get; set; }
        public int? ID_Seminar { get; set; }
        [Required(ErrorMessage = "Last known salary is required")]
        public decimal? CurrentSalary { get; set; }

        [Required(ErrorMessage = "Asking salary is required")]
        public decimal? AskingSalary { get; set; }

        public bool ContactPreviousEmployer { get; set; }

    }
}
