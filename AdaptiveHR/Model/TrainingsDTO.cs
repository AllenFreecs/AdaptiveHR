using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class TrainingsDTO
    {
	   public int Id { get; set; }
       public string Training { get; set; }
public DateTime? DateTime { get; set; }
public string Location { get; set; }
public string Participants { get; set; }
public bool OBRequired { get; set; }
public bool IsApproved { get; set; }

    }
}
