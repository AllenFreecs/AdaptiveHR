using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class PayslipDTO
    {
	   public int Id { get; set; }
       public int? ID_Employee { get; set; }
public int? ID_PayrollUpLoad { get; set; }
public int? ID_PayrollItemType { get; set; }
public string PayrollItem { get; set; }
public decimal? Amount { get; set; }

    }
}
