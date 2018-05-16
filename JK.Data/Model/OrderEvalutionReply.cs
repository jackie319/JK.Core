using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderEvalutionReply
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid EvaluationGuid { get; set; }
        public string Replier { get; set; }
        public string ReplyContent { get; set; }
        public bool IsSystem { get; set; }
        public bool IsDisplay { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
