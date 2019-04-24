using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class LeaveDetail
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Date { get; set; }
        public int? IdWorkType { get; set; }
        public decimal? Hours { get; set; }
        public bool? WithPay { get; set; }
    }
}
