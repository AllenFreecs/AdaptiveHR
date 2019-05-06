using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class LeaveDTO
    {
	   public int Id { get; set; }
       public int? ID_LeaveType { get; set; }
public string Description { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }
public bool IsApproved { get; set; }

    }
}
