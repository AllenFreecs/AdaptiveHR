using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class Training_detailDTO
    {
	   public int Id { get; set; }
       public int? ID_Employee { get; set; }
public int? ID_TrainingResponse { get; set; }
public string TrainingNote { get; set; }
public DateTime? DateAccepted { get; set; }

    }
}
