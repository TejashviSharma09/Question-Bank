using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class EmpSkillSet
    {
        public int? EmpId { get; set; }
        public int? SkillId { get; set; }

        public virtual Employee? Emp { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}
