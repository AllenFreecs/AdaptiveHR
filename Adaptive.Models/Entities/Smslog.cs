using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Smslog
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdSmsprofile { get; set; }
        public string Message { get; set; }
        public bool? IsSent { get; set; }
    }
}
