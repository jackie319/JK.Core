using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderRefund = new HashSet<OrderRefund>();
            ProductAlbum = new HashSet<ProductAlbum>();
            ProductClassification = new HashSet<ProductClassification>();
            ProductParameters = new HashSet<ProductParameters>();
            ProductPurchaseRecords = new HashSet<ProductPurchaseRecords>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryGuid { get; set; }
        public int ProductNumber { get; set; }
        public string ProductNo { get; set; }
        public string DefaultPic { get; set; }
        public string SaleTitle { get; set; }
        public string SaleSubTitle { get; set; }
        public int Price { get; set; }
        public int PromotionPrice { get; set; }
        public string ProductDetail { get; set; }
        public string ProductRemark { get; set; }
        public string Status { get; set; }
        public bool IsSpecialOffer { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsAd { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
        public int ImaginaryNumber { get; set; }
        public int VisitedTotal { get; set; }
        public int SoldTotal { get; set; }
        public int EvaluationToTal { get; set; }
        public DateTime TimeOnShelf { get; set; }
        public DateTime TimeOffShelf { get; set; }
        public DateTime TimeCreated { get; set; }

        public ICollection<OrderRefund> OrderRefund { get; set; }
        public ICollection<ProductAlbum> ProductAlbum { get; set; }
        public ICollection<ProductClassification> ProductClassification { get; set; }
        public ICollection<ProductParameters> ProductParameters { get; set; }
        public ICollection<ProductPurchaseRecords> ProductPurchaseRecords { get; set; }
    }
}
