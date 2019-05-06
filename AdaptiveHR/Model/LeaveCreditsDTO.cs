using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class LeaveCreditsDTO
    {
	   public int Id { get; set; }
       public int? ID_Employee { get; set; }
public int? ID_LeaveType { get; set; }
public decimal? Accrual { get; set; }
public bool IsForfeited { get; set; }

    }
}
