using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Article
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid CategoryGuid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Detail { get; set; }
        public bool IsDisplay { get; set; }
        public bool IsDeleted { get; set; }
        public Guid AdminUserGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public ArticleCategory CategoryGu { get; set; }
    }
}
