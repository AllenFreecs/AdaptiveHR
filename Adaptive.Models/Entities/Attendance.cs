using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? WorkDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? DateAccepted { get; set; }
    }
}
