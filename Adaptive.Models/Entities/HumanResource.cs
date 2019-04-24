using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class HumanResource
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdPds { get; set; }
        public int? IdCompany { get; set; }
        public int? IdHumanResourceStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Value { get; set; }
        public bool? NotifyAdminAfterDays { get; set; }
    }
}
