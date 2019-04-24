using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Job
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdPds { get; set; }
        public string Job1 { get; set; }
        public string CompanyName { get; set; }
        public string DescriptIon { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReasonForLeaving { get; set; }
    }
}
