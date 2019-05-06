using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class SMSProfileDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public string Description { get; set; }
public string Message { get; set; }
public int? Port { get; set; }

    }
}
