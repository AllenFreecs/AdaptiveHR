using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class HumanResourceDTO
    {
	   public int Id { get; set; }
       public int? ID_PDS { get; set; }
public int? ID_Company { get; set; }
public int? ID_HumanResourceStatus { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }
public decimal? Value { get; set; }
public bool NotifyAdminAfterDays { get; set; }

    }
}
