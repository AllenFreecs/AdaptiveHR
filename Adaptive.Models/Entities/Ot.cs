using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Ot
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Otdate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Hours { get; set; }
    }
}
