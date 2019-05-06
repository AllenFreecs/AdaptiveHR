using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class PayrollUploadDTO
    {
	   public int Id { get; set; }
       public string Name { get; set; }
public DateTime? CutoffPeriodStartDate { get; set; }
public DateTime? CutoffPeriodEndDate { get; set; }
public string UploadedFile { get; set; }
public bool IsPosted { get; set; }

    }
}
