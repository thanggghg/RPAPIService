using RP.Affiliate.Tracking.Database.Entities;
using RP.Affiliate.Tracking.Entities;
using RP.Library.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace RP.Affiliate.Tracking.Database
{
    public class AffiliateContext : BaseContext
    {
        public DbSet<AffiliateClickTracking> AffiliateClickTrackings { get; set; }
        public DbSet<AffiliateLink> AffiliateLinks { get; set; }
        public DbSet<AffiliateCommission> AffiliateCommissions { get; set; }
        public DbSet<AffiliateProduct> AffiliateProducts { get; set; }
        public DbSet<AffiliateTrackingManagement> AffiliateTrackingManagements { get; set; }
        public DbSet<AffiliateCampaign> AffiliateCampaigns { get; set; }
        public DbSet<AffiliateCampaignProduct> AffiliateCampaignProducts { get; set; }
        public DbSet<AffiliateStore> AffiliateStore { get; set; }
        public DbSet<AffiliateSubmission> AffiliateSubmission { get; set; }
        public DbSet<AffiliateOrderDetail> AffiliateOrderDetail { get; set; }
        public DbSet<AffiliateCategory> AffiliateCategory { get; set; }
        public DbSet<AffiliateCollection> AffiliateCollection { get; set; }

        public DbSet<AffiliateBusiness> AffiliateBusiness { get; set; }
        public DbSet<AffiliateColorDefault> AffiliateColorDefault { get; set; }
        public DbSet<AffiliateStoreCurrency> AffiliateStoreCurrencies{ get; set; }
        public DbSet<AffiliateMapping> AffiliateMappings { get; set; }
        public DbSet<AffiliateOrderTracking> AffiliateOrderTracking { get; set; }

        public AffiliateContext(DbContextOptions<AffiliateContext> options, IMediator mediator) : base(options, mediator)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SequenceConfig(modelBuilder);
            AffiliateCampaignConfig(modelBuilder);
            AffiliateClickTrackingConfig(modelBuilder);
            AffiliateCommissiontConfig(modelBuilder);
            AffiliateLinkConfig(modelBuilder);
            AffiliateProductConfig(modelBuilder);
            AffiliateTrackingManagementConfig(modelBuilder);
            AffiliateThemeConfig(modelBuilder);
            AffiliateSubmissionConfig(modelBuilder);
            AffiliateOrderDetailConfig(modelBuilder);
            AffiliateCategoryConfig(modelBuilder);
            AffiliateCollectionConfig(modelBuilder);
            AffiliateStoreConfig(modelBuilder);
            AffiliateBusinessConfig(modelBuilder);
            AffiliateColorDefaultConfig(modelBuilder);
            AffiliateMappingConfig(modelBuilder);
            AffiliateOrderTrackingConfig(modelBuilder);
            AffiliateCampaignProductConfig(modelBuilder);
            AffiliateStoreCurrencyConfig(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void AffiliateClickTrackingConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateClickTracking>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateClickTracking>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_click_tracking_id_seq", schema: "affiliate-tracking-services");
        }

        private void AffiliateOrderTrackingConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateOrderTracking>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateOrderTracking>()
                        .Property(x => x.IsDeleted)
                        .HasDefaultValue(false);
            modelBuilder.Entity<AffiliateOrderTracking>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_order_tracking_id_seq", schema: "affiliate-tracking-services");
        }

        private void AffiliateLinkConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateLink>()
                        .HasOne(x => x.AffiliateProduct)
                        .WithMany(x => x.AffiliateLinks)
                        .HasConstraintName("fk_link_product")
                        .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<AffiliateLink>()
                        .HasOne(x => x.AffiliateCampaign)
                        .WithMany(x => x.AffiliateLinks)
                        .HasConstraintName("fk_link_campaign")
                        .HasForeignKey(x => x.CampaignId);
            modelBuilder.Entity<AffiliateLink>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateLink>()
                        .Property(x => x.TrackingId)
                        .HasColumnType("uuid");
            modelBuilder.Entity<AffiliateLink>()
                        .HasIndex(x => x.TrackingId)
                        .IsUnique();
            modelBuilder.Entity<AffiliateLink>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_link_id_seq", schema: "affiliate-tracking-services");
        }
        private void AffiliateCommissiontConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateCommission>()
                        .HasOne(x => x.AffiliateProduct)
                        .WithOne(x => x.AffiliateCommission)
                        .HasConstraintName("fk_commission_product")
                        .HasForeignKey<AffiliateCommission>(x => x.ProductId);
            modelBuilder.Entity<AffiliateCommission>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateCommission>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_commission_id_seq", schema: "affiliate-tracking-services");
        }
        private void AffiliateTrackingManagementConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .HasOne(x => x.AffiliateProduct)
                        .WithMany(x => x.AffiliateTrackingManagements)
                        .HasConstraintName("fk_tracking_product")
                        .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .HasOne(x => x.AffiliateLink)
                        .WithMany(x => x.AffiliateTrackingManagements)
                        .HasConstraintName("fk_tracking_link")
                        .HasPrincipalKey(x => x.TrackingId)
                        .HasForeignKey(x => x.TrackingId);
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .Property(x => x.TotalHits)
                        .HasDefaultValue(0);
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .Property(x => x.TotalClicks)
                        .HasDefaultValue(0);
            modelBuilder.Entity<AffiliateTrackingManagement>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_tracking_management_id_seq", schema: "affiliate-tracking-services");
        }
        private void AffiliateCampaignConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateCampaign>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_campaign_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateCampaign>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<AffiliateCampaign>()
                        .HasOne(x => x.AffiliateStore)
                        .WithMany(x => x.AffiliateCampaigns)
                        .HasForeignKey(x => x.AffiliateStoreId)
                        .HasConstraintName("fk_campaign_affiliate_store");
        }
        private void AffiliateProductConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateProduct>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_product_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateProduct>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateProduct>()
                        .HasOne(x => x.AffiliateStore)
                        .WithMany(x => x.AffiliateProducts)
                        .HasForeignKey(x => x.AffiliateStoreId)
                        .HasConstraintName("fk_affiliate_product_store");
            modelBuilder.Entity<AffiliateProduct>()
                       .HasOne(x => x.AffiliateCategory)
                       .WithMany(x => x.AffiliateProducts)
                       .HasForeignKey(x => x.CategoryId)
                       .HasConstraintName("fk_product_category");
            modelBuilder.Entity<AffiliateProduct>()
                       .HasOne(x => x.AffiliateCollection)
                       .WithMany(x => x.AffiliateProducts)
                       .HasForeignKey(x => x.CollectionId)
                       .HasConstraintName("fk_product_collection");
        }
        private void AffiliateStoreConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateStore>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_store_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateStore>()
                        .Property(x => x.AllowPublisherRegister)
                        .HasDefaultValue(false);
            modelBuilder.Entity<AffiliateStore>()
                        .Property(x => x.AutoApproved)
                        .HasDefaultValue(false);
            modelBuilder.Entity<AffiliateStore>()
                        .Property(x => x.CookieDurationDay)
                        .HasDefaultValue(30);
            modelBuilder.Entity<AffiliateStore>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateStore>()
                       .Property(x => x.AllowGetOrderTrackingUrl)
                       .HasDefaultValue(false);
            modelBuilder.Entity<AffiliateStore>()
                       .Property(x => x.AllowGetOrderTrackingCode)
                       .HasDefaultValue(false);
            modelBuilder.Entity<AffiliateStore>()
                      .HasOne(x => x.AffiliateBusiness)
                      .WithMany(x => x.AffiliateStores)
                      .HasConstraintName("fk_store_business")
                      .HasForeignKey(x => x.BusinessId);
        }

        private void AffiliateThemeConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateTheme>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_theme_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateTheme>()
                        .HasOne(x => x.AffiliateStore)
                        .WithMany(x => x.AffiliateThemes)
                        .HasForeignKey(x => x.StoreId)
                        .HasConstraintName("fk_theme_store");
            modelBuilder.Entity<AffiliateTheme>()
                        .HasOne(x => x.AffiliateColorDefault)
                        .WithMany(x => x.AffiliateThemes)
                        .HasForeignKey(x => x.ColorId)
                        .HasConstraintName("fk_theme_color_default");
            modelBuilder.Entity<AffiliateTheme>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateTheme>()
                        .Property(x => x.IsDeleted)
                        .HasDefaultValue(false);
        }

        private void AffiliateSubmissionConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateSubmission>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_submission_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateSubmission>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateSubmission>()
                        .Property(x => x.LastModifiedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateSubmission>()
                        .Property(x => x.IsDeleted)
                        .HasDefaultValue(false);
        }

        private void AffiliateOrderDetailConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateOrderDetail>()
                        .HasOne(x => x.AffiliateSubmission)
                        .WithMany(x => x.AffiliateOrderDetails)
                        .HasConstraintName("fk_submission_order_detail")
                        .HasForeignKey(x => x.SubmissionId);
            modelBuilder.Entity<AffiliateOrderDetail>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_order_detail_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateOrderDetail>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateOrderDetail>()
                        .Property(x => x.LastModifiedDate)
                        .HasDefaultValueSql("now()");
        }

        private void AffiliateBusinessConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateBusiness>()
                .Property(x => x.Id)
                .UseSequence("affiliate_business_id_seq", schema: "affiliate-tracking-services");
        }

        private void AffiliateColorDefaultConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateColorDefault>()
                .Property(x => x.Id)
                .UseSequence("affiliate_color_default_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateColorDefault>()
               .Property(x => x.BusinessId)
               .HasDefaultValue(0);
        }

        private void SequenceConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("affiliate_click_tracking_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_tracking_management_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_partner_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_campaign_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_commission_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_link_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_product_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_store_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_theme_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_transaction_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_transaction_detail_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_category_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
            modelBuilder.HasSequence<long>("affiliate_collection_id_seq", schema: "affiliate-tracking-services")
                        .StartsAt(1)
                        .IncrementsBy(1)
                        .HasMin(1)
                        .HasMax(9223372036854775807);
        }

        private void AffiliateCategoryConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateCategory>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_category_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateCategory>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateCategory>()
                        .Property(x => x.LastModifiedDate)
                        .HasDefaultValueSql("now()");
        }

        private void AffiliateCollectionConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateCollection>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_collection_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateCollection>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateCollection>()
                        .Property(x => x.LastModifiedDate)
                        .HasDefaultValueSql("now()");
        }

        private void AffiliateMappingConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateMapping>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_mapping_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateMapping>()
                        .HasOne(x => x.AffiliateStore)
                        .WithMany(x => x.AffiliateMappings)
                        .HasConstraintName("fk_mapping_store")
                        .HasForeignKey(x => x.AffiliateStoreId);

        }

        private void AffiliateCampaignProductConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateCampaignProduct>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_campaign_product_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateCampaignProduct>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now() at time zone 'utc'");
            modelBuilder.Entity<AffiliateCampaignProduct>()
                        .HasOne(x => x.AffiliateProduct)
                        .WithMany(x => x.AffiliateCampaignProducts)
                        .HasForeignKey(x => x.AffiliateProductId)
                        .HasConstraintName("fk_affiliate_product_id");
            modelBuilder.Entity<AffiliateCampaignProduct>()
                        .HasOne(x => x.AffiliateCampaign)
                        .WithMany(x => x.AffiliateCampaignProducts)
                        .HasForeignKey(x => x.AffiliateCampaignId)
                        .HasConstraintName("fk_affiliate_campaign_id");
        }

        private void AffiliateStoreCurrencyConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliateStoreCurrency>()
                        .Property(x => x.Id)
                        .UseSequence("affiliate_store_currency_id_seq", schema: "affiliate-tracking-services");
            modelBuilder.Entity<AffiliateStoreCurrency>()
                        .Property(x => x.CreatedDate)
                        .HasDefaultValueSql("now()");
            modelBuilder.Entity<AffiliateStoreCurrency>()
                        .Property(x => x.LastModifiedBy)
                        .HasDefaultValueSql("now()");
        }
    }
}
