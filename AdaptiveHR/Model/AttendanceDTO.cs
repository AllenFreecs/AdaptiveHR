using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class AttendanceDTO
    {
	   public int Id { get; set; }
       public int? ID_Employee { get; set; }
public DateTime? WorkDate { get; set; }
public DateTime? StartTime { get; set; }
public DateTime? EndTime { get; set; }
public DateTime? DateAccepted { get; set; }

    }
}
