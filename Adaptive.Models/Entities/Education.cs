using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Education
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdPds { get; set; }
        public int? IdEducationLevel { get; set; }
        public string Address { get; set; }
        public string Awards { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
