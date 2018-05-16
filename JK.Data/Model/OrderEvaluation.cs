using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderEvaluation
    {
        public OrderEvaluation()
        {
            OrderEvaluationPic = new HashSet<OrderEvaluationPic>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public Guid ClassificationGuid { get; set; }
        public string ClassificationName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string UserNickName { get; set; }
        public int DescriptionOfGoodGrade { get; set; }
        public int LogisticsGrade { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSystemEvaluated { get; set; }
        public string EvaluationContent { get; set; }
        public bool IsDisplay { get; set; }
        public DateTime TimeCreated { get; set; }

        public Order OrderGu { get; set; }
        public ICollection<OrderEvaluationPic> OrderEvaluationPic { get; set; }
    }
}
