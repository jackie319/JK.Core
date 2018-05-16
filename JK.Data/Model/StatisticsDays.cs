using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class StatisticsDays
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string RecordsDay { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
