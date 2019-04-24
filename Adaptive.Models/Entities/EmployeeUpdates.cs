using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class EmployeeUpdates
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string ChangeNumber { get; set; }
        public int? IdStatus { get; set; }
        public int? IdReason { get; set; }
        public int? IdEmployee { get; set; }
    }
}
