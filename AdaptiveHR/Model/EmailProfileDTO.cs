using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EmailProfileDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public int? Port { get; set; }
public bool UseSSL { get; set; }

    }
}
