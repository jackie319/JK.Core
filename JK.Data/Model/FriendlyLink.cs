using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class FriendlyLink
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
