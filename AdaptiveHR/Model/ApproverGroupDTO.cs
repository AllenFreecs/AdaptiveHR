using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class ApproverGroupDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public bool IsIncrement { get; set; }
public bool ApprovalBeforeIncrement { get; set; }

    }
}