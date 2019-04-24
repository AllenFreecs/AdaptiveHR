using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class ApplicationSchedule
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdPds { get; set; }
        public DateTime? DateScheduled { get; set; }
        public DateTime? TimeScheduled { get; set; }
    }
}
