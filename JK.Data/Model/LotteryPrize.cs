using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class LotteryPrize
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid PrizeActivityGuid { get; set; }
        public int Grade { get; set; }
        public string PrizeType { get; set; }
        public string PrizeName { get; set; }
        public int Money { get; set; }
        public int TotalNum { get; set; }
        public int WinningRate { get; set; }
        public string DefaultPic { get; set; }
        public string Detail { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public LotteryActivity PrizeActivityGu { get; set; }
    }
}
