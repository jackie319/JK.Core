using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductParameters
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        public string Brand { get; set; }
        public string TimeToMarket { get; set; }
        public string Material { get; set; }
        public string MosaicMaterial { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string Style { get; set; }
        public string ApplyPeople { get; set; }
        public string SalesChannels { get; set; }
        public DateTime TimeCreated { get; set; }

        public Product ProductGu { get; set; }
    }
}
