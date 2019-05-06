using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class SeminarDTO
    {
	   public int Id { get; set; }
       public int? ID_PDS { get; set; }
public string Seminar { get; set; }
public string Location { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }

    }
}
