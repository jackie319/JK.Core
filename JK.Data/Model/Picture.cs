using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Picture
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
