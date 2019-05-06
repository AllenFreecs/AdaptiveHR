using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class OBDTO
    {
	   public int Id { get; set; }
       public int? ID_Training { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }
public DateTime? StartTime { get; set; }
public DateTime? EndTime { get; set; }
public bool IsApproved { get; set; }

    }
}
