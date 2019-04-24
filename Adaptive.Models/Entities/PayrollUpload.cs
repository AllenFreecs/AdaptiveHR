using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class PayrollUpload
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public DateTime? CutoffPeriodStartDate { get; set; }
        public DateTime? CutoffPeriodEndDate { get; set; }
        public string UploadedFile { get; set; }
        public bool? IsPosted { get; set; }
    }
}
