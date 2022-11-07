using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public int? SkillCategory { get; set; }

        public virtual SkillCategory? SkillCategoryNavigation { get; set; }
    }
}
