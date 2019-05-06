using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EducationDTO
    {
	   public int Id { get; set; }
       public int? ID_PDS { get; set; }
public int? ID_EducationLevel { get; set; }
public string Address { get; set; }
public string Awards { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? EndDate { get; set; }

    }
}
