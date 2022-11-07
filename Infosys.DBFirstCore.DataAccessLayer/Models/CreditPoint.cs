using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class CreditPoint
    {
        public int? EmpId { get; set; }
        public int? Points { get; set; }

        public virtual Employee? Emp { get; set; }
    }
}
