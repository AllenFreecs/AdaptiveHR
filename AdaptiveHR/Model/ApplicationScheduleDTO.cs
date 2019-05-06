using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class ApplicationScheduleDTO
    {
	   public int Id { get; set; }
       public int? ID_PDS { get; set; }
public DateTime? DateScheduled { get; set; }
public DateTime? TimeScheduled { get; set; }

    }
}
