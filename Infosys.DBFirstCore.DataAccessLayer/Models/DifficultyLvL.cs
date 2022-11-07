using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class DifficultyLvL
    {
        public int? QuesId { get; set; }
        public int? DiffLvL { get; set; }

        public virtual Question? Ques { get; set; }
    }
}
