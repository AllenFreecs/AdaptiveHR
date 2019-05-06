using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EmployeeUpdatesDTO
    {
	   public int Id { get; set; }
       public string ChangeNumber { get; set; }
public int? ID_Status { get; set; }
public int? ID_Reason { get; set; }
public int? ID_Employee { get; set; }

    }
}
