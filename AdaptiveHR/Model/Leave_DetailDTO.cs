using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class Leave_DetailDTO
    {
	   public int Id { get; set; }
       public DateTime? Date { get; set; }
public int? ID_WorkType { get; set; }
public decimal? Hours { get; set; }
public bool WithPay { get; set; }

    }
}
