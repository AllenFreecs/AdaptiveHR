using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR.Model
{
    public class JobDTO
    {
        public int Id { get; set; }
        public int? ID_PDS { get; set; }
        public string Job { get; set; }
        public string CompanyName { get; set; }
        public string DescriptIon { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReasonForLeaving { get; set; }

    }
}
