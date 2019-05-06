using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class OTDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public string Description { get; set; }
public DateTime? OTDate { get; set; }
public DateTime? StartTime { get; set; }
public DateTime? EndTime { get; set; }
public decimal? Hours { get; set; }

    }
}
