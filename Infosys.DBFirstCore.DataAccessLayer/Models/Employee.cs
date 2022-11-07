using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class Employee
    {
        public Employee()
        {
            QuestionContributors = new HashSet<Question>();
            QuestionReviewers = new HashSet<Question>();
        }

        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Question> QuestionContributors { get; set; }
        public virtual ICollection<Question> QuestionReviewers { get; set; }
    }
}
