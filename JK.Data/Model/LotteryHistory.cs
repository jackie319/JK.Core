using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class LotteryHistory
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public Guid PrizeActivityGuid { get; set; }
        public bool IsWenner { get; set; }
        public Guid PrizeGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public LotteryActivity PrizeActivityGu { get; set; }
        public UserAccount UserGu { get; set; }
    }
}
