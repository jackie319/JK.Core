using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class AppVersion
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Project { get; set; }
        public string Version { get; set; }
        public string IosdownLoadUrl { get; set; }
        public string AndroidDownLoadUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
