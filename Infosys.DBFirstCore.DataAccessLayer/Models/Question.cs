using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class Question
    {
        public int QuesId { get; set; }
        public int? QuesTypeId { get; set; }
        public string QuesDesc { get; set; } = null!;
        public int ContributorId { get; set; }
        public int? ReviewerId { get; set; }
        public int? Status { get; set; }

        public virtual Employee Contributor { get; set; } = null!;
        public virtual QuestionType? QuesType { get; set; }
        public virtual Employee? Reviewer { get; set; }
    }
}
