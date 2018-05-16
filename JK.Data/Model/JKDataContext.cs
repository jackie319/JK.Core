using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JK.Data.Model
{
    public partial class JKDataContext : DbContext
    {
        public virtual DbSet<AppVersion> AppVersion { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }
        public virtual DbSet<AuthorityFunction> AuthorityFunction { get; set; }
        public virtual DbSet<AuthorityRole> AuthorityRole { get; set; }
        public virtual DbSet<AuthorityRoleInFunction> AuthorityRoleInFunction { get; set; }
        public virtual DbSet<AuthorityUserInRole> AuthorityUserInRole { get; set; }
        public virtual DbSet<FriendlyLink> FriendlyLink { get; set; }
        public virtual DbSet<Fxjlsetting> Fxjlsetting { get; set; }
        public virtual DbSet<LotteryActivity> LotteryActivity { get; set; }
        public virtual DbSet<LotteryHistory> LotteryHistory { get; set; }
        public virtual DbSet<LotteryJackpot> LotteryJackpot { get; set; }
        public virtual DbSet<LotteryPrize> LotteryPrize { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderEvaluation> OrderEvaluation { get; set; }
        public virtual DbSet<OrderEvaluationPic> OrderEvaluationPic { get; set; }
        public virtual DbSet<OrderEvalutionReply> OrderEvalutionReply { get; set; }
        public virtual DbSet<OrderPayment> OrderPayment { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<OrderRefund> OrderRefund { get; set; }
        public virtual DbSet<OrderShippingMethod> OrderShippingMethod { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAlbum> ProductAlbum { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductClassification> ProductClassification { get; set; }
        public virtual DbSet<ProductParameters> ProductParameters { get; set; }
        public virtual DbSet<ProductPurchaseRecords> ProductPurchaseRecords { get; set; }
        public virtual DbSet<ProductSupplier> ProductSupplier { get; set; }
        public virtual DbSet<SmsRecords> SmsRecords { get; set; }
        public virtual DbSet<StatisticsDays> StatisticsDays { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserAccountBalanceLog> UserAccountBalanceLog { get; set; }
        public virtual DbSet<UserAccountFinance> UserAccountFinance { get; set; }
        public virtual DbSet<UserAccountFinanceChangeRecords> UserAccountFinanceChangeRecords { get; set; }
        public virtual DbSet<UserAccountWechat> UserAccountWechat { get; set; }
        public virtual DbSet<UserDeliveryAddress> UserDeliveryAddress { get; set; }
        public virtual DbSet<UserLoginRecords> UserLoginRecords { get; set; }
        public virtual DbSet<UserOperationRecords> UserOperationRecords { get; set; }
        public virtual DbSet<UserShoppingCart> UserShoppingCart { get; set; }
        public virtual DbSet<WechatPayNotify> WechatPayNotify { get; set; }
        public virtual DbSet<WechatPayRecords> WechatPayRecords { get; set; }
        public virtual DbSet<WechatPayRefundNotify> WechatPayRefundNotify { get; set; }
        public virtual DbSet<WechatPayRefundRecords> WechatPayRefundRecords { get; set; }
        public virtual DbSet<WithdrawCashOrder> WithdrawCashOrder { get; set; }
        public virtual DbSet<WithdrawCashRecords> WithdrawCashRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=120.78.156.158;Database=JKData;UID=jk;PWD=jackie;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppVersion>(entity =>
               {
                   entity.HasKey(e => e.Guid)
                       .ForSqlServerIsClustered(false);

                   entity.HasIndex(e => e.Id)
                       .HasName("IX_AppVersion")
                       .ForSqlServerIsClustered();

                   entity.Property(e => e.Guid).ValueGeneratedNever();

                   entity.Property(e => e.AndroidDownLoadUrl)
                       .IsRequired()
                       .HasMaxLength(200)
                       .IsUnicode(false);

                   entity.Property(e => e.Id).ValueGeneratedOnAdd();

                   entity.Property(e => e.IosdownLoadUrl)
                       .IsRequired()
                       .HasColumnName("IOSDownLoadUrl")
                       .HasMaxLength(200)
                       .IsUnicode(false);

                   entity.Property(e => e.Project)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(false);

                   entity.Property(e => e.Version)
                       .IsRequired()
                       .HasMaxLength(50)
                       .IsUnicode(false);
               });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Detail).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SubTitle)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CategoryGu)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.CategoryGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_ArticleCategory");
            });

            modelBuilder.Entity<ArticleCategory>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.ActionUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DisplayPosition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthorityFunction>(entity =>
            {
                entity.HasKey(e => e.FunctionGuid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.FunctionGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActionUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PlatForm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AuthorityRole>(entity =>
            {
                entity.HasKey(e => e.RoleGuid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleEnumName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AuthorityRoleInFunction>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FunctionGu)
                    .WithMany(p => p.AuthorityRoleInFunction)
                    .HasForeignKey(d => d.FunctionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleInFunction_Function");

                entity.HasOne(d => d.RoleGu)
                    .WithMany(p => p.AuthorityRoleInFunction)
                    .HasForeignKey(d => d.RoleGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleInFunction_Role");
            });

            modelBuilder.Entity<AuthorityUserInRole>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RoleGu)
                    .WithMany(p => p.AuthorityUserInRole)
                    .HasForeignKey(d => d.RoleGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInRole_Role");
            });

            modelBuilder.Entity<FriendlyLink>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WebTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WebUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fxjlsetting>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("FXJLSetting");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<LotteryActivity>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.DefaultPic)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Detail).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LotteryHistory>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.HasOne(d => d.PrizeActivityGu)
                    .WithMany(p => p.LotteryHistory)
                    .HasForeignKey(d => d.PrizeActivityGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LotteryHistory_PrizeActivity");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.LotteryHistory)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LotteryHistory_UserAccount");
            });

            modelBuilder.Entity<LotteryJackpot>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeUpdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<LotteryPrize>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.DefaultPic)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PrizeName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PrizeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrizeActivityGu)
                    .WithMany(p => p.LotteryPrize)
                    .HasForeignKey(d => d.PrizeActivityGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prize_PrizeActivity");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Order")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LogisticsCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderRemark)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShippingRemark)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserNickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderEvaluation>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_OrderEvaluation")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClassificationName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EvaluationContent)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserNickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OrderGu)
                    .WithMany(p => p.OrderEvaluation)
                    .HasForeignKey(d => d.OrderGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderEvaluation_Order");
            });

            modelBuilder.Entity<OrderEvaluationPic>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_OrderEvaluationPic")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.EvaluationGu)
                    .WithMany(p => p.OrderEvaluationPic)
                    .HasForeignKey(d => d.EvaluationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderEvaluationPic_OrderEvaluation");
            });

            modelBuilder.Entity<OrderEvalutionReply>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_OrderEvalutionReply")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Replier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<OrderPayment>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClassificationName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DefaultPic)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrderGu)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.OrderGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Order");
            });

            modelBuilder.Entity<OrderRefund>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.CheckRefundRemark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RefundNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundRemark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClassificationGu)
                    .WithMany(p => p.OrderRefund)
                    .HasForeignKey(d => d.ClassificationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderRefund_ProductClassification");

                entity.HasOne(d => d.OrderGu)
                    .WithMany(p => p.OrderRefund)
                    .HasForeignKey(d => d.OrderGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderRefund_Order");

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.OrderRefund)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderRefund_Product");
            });

            modelBuilder.Entity<OrderShippingMethod>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ShipperCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Picture")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Product")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DefaultPic)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductDetail).IsRequired();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ProductNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductRemark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SaleSubTitle)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SaleTitle)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeOffShelf).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeOnShelf).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductAlbum>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductAlbum")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.ProductAlbum)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAlbum_Product");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductCategory")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductClassification>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductClassification")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Grams).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PicUrl)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.ProductClassification)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductClassification_Product");
            });

            modelBuilder.Entity<ProductParameters>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductParameters")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.ApplyPeople)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MosaicMaterial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlaceOfOrigin)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SalesChannels)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeToMarket)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.ProductParameters)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductParameters_Product");
            });

            modelBuilder.Entity<ProductPurchaseRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductPurchaseRecords")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.ClassificationName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OperatorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Purchaser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.ProductPurchaseRecords)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPurchaseRecords_Product");
            });

            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_ProductSupplier")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SupplierPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SmsRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_SmsRecords")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RadomCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ResultStatusCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SmsType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeUpdate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StatisticsDays>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RecordsDay)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Addreess)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Detail).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AvatarImgUrl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ipv4LastVisited)
                    .IsRequired()
                    .HasColumnName("IPv4LastVisited")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recommender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserAccountBalanceLog>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccountFinance>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserAccountFinanceChangeRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_UserAccountFinanceChangeRecords")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ChangeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserAccountWechat>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Privilege)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SessionKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unionid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WechatAvatarImgUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WechatNickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WechatOpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAccountGu)
                    .WithMany(p => p.UserAccountWechat)
                    .HasForeignKey(d => d.UserAccountGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccountWechat_UserAccount");
            });

            modelBuilder.Entity<UserDeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.UserDeliveryAddress)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDeliveryAddress_UserAccount");
            });

            modelBuilder.Entity<UserLoginRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserOperationRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.UserOperationRecords)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOperationRecords_UserAccount");
            });

            modelBuilder.Entity<UserShoppingCart>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("IX_UserShoppingCart")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.UserShoppingCart)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserShoppingCart_UserAccount");
            });

            modelBuilder.Entity<WechatPayNotify>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attach)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BankType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCodeDes)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsSubscribe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MchId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonceStr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnMsg)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeEnd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TradeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatPayRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CodeUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCodeDes)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NonceStr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrepayId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultSign)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnMsg)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SpbillCreateIp)
                    .IsRequired()
                    .HasColumnName("SpbillCreateIP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TradeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserOpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatPayRefundNotify>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Appid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MchId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonceStr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutRefundNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundRecvAccout)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RefundRequestSource)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReqInfo)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnMsg)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SuccessTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WechatPayRefundRecords>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.Appid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCodeDes)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MchId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonceStr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutRefundNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundDesc)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RefundFeeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefundId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnMsg)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WithdrawCashOrder>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.WithdrawCashOrder)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WithdrawCashOrder_UserAccount");
            });

            modelBuilder.Entity<WithdrawCashRecords>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.CheckName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrCodeDes)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MchAppId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MchId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonceStr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpenId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutTradeNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerTradeNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PayKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpbillCreateIp)
                    .IsRequired()
                    .HasColumnName("SpbillCreateIP")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
