using System;
using System.Collections.Generic;

namespace Adaptive.Models.Entities
{
    public partial class Payslip
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdPayrollUpLoad { get; set; }
        public int? IdPayrollItemType { get; set; }
        public string PayrollItem { get; set; }
        public decimal? Amount { get; set; }
    }
}
