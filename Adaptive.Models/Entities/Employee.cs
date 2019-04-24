using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string SessionId { get; set; }
        public int? IdPds { get; set; }
        public string EmployeeCode { get; set; }
        public bool? RequiredToLog { get; set; }
        public decimal? Salary { get; set; }
        public int? IdPayScheme { get; set; }
        public int? IdPayrollParameter { get; set; }
        public int? IdPosition { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdBranch { get; set; }
        public int? IdEmployeeStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HealthCardNumber { get; set; }
        public string FathersName { get; set; }
        public string FathersLastName { get; set; }
        public string FathersFirstName { get; set; }
        public string FathersMiddleName { get; set; }
        public DateTime? FathersBirthDay { get; set; }
        public string MothersName { get; set; }
        public string MothersMaidenLastName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public DateTime? MotherBirthDay { get; set; }
        public string SpouseName { get; set; }
        public string SpouseMaidenLastName { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseMiddleName { get; set; }
        public DateTime? SpouseBirthDay { get; set; }
        public int? FingerPrintId { get; set; }
        public int? FaceRecognitionId { get; set; }
        public int? AndroidId { get; set; }
        public int? IdDocAddress { get; set; }
        public int? IdDefaultSchedule { get; set; }
        public int? OtapproverGroup { get; set; }
        public int? ObapproverGroup { get; set; }
        public int? LeaveApproverGroup { get; set; }
    }
}
