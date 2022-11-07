﻿using System;
using System.Collections.Generic;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class Mcqanswer
    {
        public int? QuestionId { get; set; }
        public string? Option1 { get; set; }
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
        public string? Option5 { get; set; }
        public string? Answer { get; set; }

        public virtual Question? Question { get; set; }
    }
}
