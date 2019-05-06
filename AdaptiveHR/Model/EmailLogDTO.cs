using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EmailLogDTO
    {
	   public int Id { get; set; }
       public int? ID_EmailProfile { get; set; }
public string Message { get; set; }
public bool IsSent { get; set; }

    }
}
