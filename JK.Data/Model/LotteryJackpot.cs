using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class LotteryJackpot
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime TimeUpdate { get; set; }
    }
}
