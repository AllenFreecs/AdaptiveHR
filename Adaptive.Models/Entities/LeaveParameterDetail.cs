using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class LeaveParameterDetail
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdLeaveParameter { get; set; }
        public int? IdLeaveType { get; set; }
        public int? IdAccrualType { get; set; }
        public bool? Forefeitable { get; set; }
        public bool? ForfeitDate { get; set; }
        public int? YearsBeforeIncrement { get; set; }
        public int? IncrementValue { get; set; }
        public int? InitialValue { get; set; }
    }
}
