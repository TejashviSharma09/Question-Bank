using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public int QtypeId { get; set; }
        public string Qtype { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
