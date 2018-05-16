using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class SmsRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public bool IsValidated { get; set; }
        public string RadomCode { get; set; }
        public string ResultStatusCode { get; set; }
        public string SmsType { get; set; }
        public string Remark { get; set; }
        public DateTime TimeUpdate { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
