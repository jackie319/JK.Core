using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderEvaluationPic
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid EvaluationGuid { get; set; }
        public Guid ImageGuid { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public OrderEvaluation EvaluationGu { get; set; }
    }
}
