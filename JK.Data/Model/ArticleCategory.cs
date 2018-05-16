using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ArticleCategory
    {
        public ArticleCategory()
        {
            Article = new HashSet<Article>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid ParentGuid { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public string Type { get; set; }
        public string DisplayPosition { get; set; }
        public string ActionUrl { get; set; }
        public bool IsDisplay { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
