using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class WorkScheduleDTO
    {
	   public int Id { get; set; }
       public int? ID_Employee { get; set; }
public DateTime? StartTime { get; set; }
public DateTime? EndTime { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }
public bool IsApproved { get; set; }

    }
}
