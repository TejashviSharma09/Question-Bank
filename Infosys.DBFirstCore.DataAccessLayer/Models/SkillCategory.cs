using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class SkillCategory
    {
        public SkillCategory()
        {
            Skills = new HashSet<Skill>();
        }

        public int CatId { get; set; }
        public string Category { get; set; } = null!;

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
