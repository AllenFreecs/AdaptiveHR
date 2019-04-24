using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class TrainingDetail
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdTrainingResponse { get; set; }
        public string TrainingNote { get; set; }
        public DateTime? DateAccepted { get; set; }
    }
}
