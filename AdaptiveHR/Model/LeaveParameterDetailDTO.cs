using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class LeaveParameterDetailDTO
    {
	   public int Id { get; set; }
       public int? ID_LeaveParameter { get; set; }
public int? ID_LeaveType { get; set; }
public int? ID_AccrualType { get; set; }
public bool Forefeitable { get; set; }
public bool ForfeitDate { get; set; }
public int? YearsBeforeIncrement { get; set; }
public int? IncrementValue { get; set; }
public int? InitialValue { get; set; }

    }
}
