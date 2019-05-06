using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EmployeeDTO
    {
	   public int Id { get; set; }
       public string SessionID { get; set; }
public int? ID_PDS { get; set; }
public string EmployeeCode { get; set; }
public bool RequiredToLog { get; set; }
public decimal? Salary { get; set; }
public int? ID_PayScheme { get; set; }
public int? ID_PayrollParameter { get; set; }
public int? ID_Position { get; set; }
public int? ID_Department { get; set; }
public int? ID_Branch { get; set; }
public int? ID_EmployeeStatus { get; set; }
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
public int? FingerPrintID { get; set; }
public int? FaceRecognitionID { get; set; }
public int? AndroidID { get; set; }
public int? ID_DocAddress { get; set; }
public int? ID_DefaultSchedule { get; set; }
public int? OTApproverGroup { get; set; }
public int? OBApproverGroup { get; set; }
public int? LeaveApproverGroup { get; set; }

    }
}
