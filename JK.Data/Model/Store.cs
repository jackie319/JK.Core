using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Store
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid StorePictureGuid { get; set; }
        public string StoreName { get; set; }
        public string Addreess { get; set; }
        public string Detail { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
