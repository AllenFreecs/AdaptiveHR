using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class ApproverGroup_DetailDTO
    {
	   public int Id { get; set; }
       public int? ID_Approver { get; set; }
public int? ID_Employee { get; set; }
public int? ApproverLevel { get; set; }

    }
}
