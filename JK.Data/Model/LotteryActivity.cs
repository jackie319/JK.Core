using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class LotteryActivity
    {
        public LotteryActivity()
        {
            LotteryHistory = new HashSet<LotteryHistory>();
            LotteryPrize = new HashSet<LotteryPrize>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int BaseNumber { get; set; }
        public string DefaultPic { get; set; }
        public string Detail { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public ICollection<LotteryHistory> LotteryHistory { get; set; }
        public ICollection<LotteryPrize> LotteryPrize { get; set; }
    }
}
