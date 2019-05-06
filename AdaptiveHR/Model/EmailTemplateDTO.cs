using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class EmailTemplateDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public string Message { get; set; }
public string Attachment { get; set; }
public bool InUse { get; set; }

    }
}
