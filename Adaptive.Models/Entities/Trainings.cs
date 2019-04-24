using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Trainings
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Training { get; set; }
        public DateTime? DateTime { get; set; }
        public string Location { get; set; }
        public string Participants { get; set; }
        public bool? Obrequired { get; set; }
        public bool? IsApproved { get; set; }
    }
}
