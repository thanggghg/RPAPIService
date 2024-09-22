using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSell.Affiliate.Tracking.Migrations
{
    /// <inheritdoc />
    public partial class AffiliateMigrationUpdate__v : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "affiliate-tracking-services");

            migrationBuilder.CreateSequence(
                name: "affiliate_business_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_campaign_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_category_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_click_tracking_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_collection_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_color_default_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_commission_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_link_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_mapping_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.CreateSequence(
                name: "affiliate_order_detail_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.CreateSequence(
                name: "affiliate_partner_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_product_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_store_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_submission_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.CreateSequence(
                name: "affiliate_theme_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_tracking_management_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_transaction_detail_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateSequence(
                name: "affiliate_transaction_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateTable(
                name: "affiliate_business",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_business_id_seq')"),
                    language_key = table.Column<string>(type: "text", nullable: false),
                    cover_image_path = table.Column<string>(type: "text", nullable: false),
                    thumbnail_image_path = table.Column<string>(type: "text", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_business", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_click_tracking",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_click_tracking_id_seq')"),
                    click_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    platform = table.Column<string>(type: "text", nullable: true),
                    device = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_click_tracking", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_collection",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_collection_id_seq')"),
                    category_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    enabled = table.Column<bool>(type: "boolean", maxLength: 500, nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_collection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_color_default",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_color_default_id_seq')"),
                    primary_color = table.Column<string>(type: "text", nullable: false),
                    secondary_color = table.Column<string>(type: "text", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    business_id = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_color_default", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_store",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_store_id_seq')"),
                    gosell_store_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    logo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    website = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    allow_publisher_register = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    auto_approved = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    cookie_duration_day = table.Column<int>(type: "integer", nullable: false, defaultValue: 30),
                    api_key = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    auto_approved_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    business_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_submission",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_submission_id_seq')"),
                    conversion_id = table.Column<string>(type: "text", nullable: true),
                    tracking_ids = table.Column<string>(type: "text", nullable: true),
                    click_id = table.Column<string>(type: "text", nullable: true),
                    external_store_id = table.Column<long>(type: "bigint", nullable: false),
                    group_id = table.Column<string>(type: "text", nullable: true),
                    submission_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    order_id = table.Column<string>(type: "text", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    order_created_date = table.Column<DateOnly>(type: "Date", nullable: false),
                    sub_total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    fee_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    tax_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    shipping_fee = table.Column<decimal>(type: "numeric", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_submission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_campaign",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_campaign_id_seq')"),
                    campaign_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    affiliate_store_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_campaign", x => x.id);
                    table.ForeignKey(
                        name: "fk_campaign_affiliate_store",
                        column: x => x.affiliate_store_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_category",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_category_id_seq')"),
                    category_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ref_category_id = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    affiliate_store_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_affiliate_category_affiliate_store_affiliate_store_id",
                        column: x => x.affiliate_store_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_mapping",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_mapping_id_seq')"),
                    mapping_key = table.Column<string>(type: "text", nullable: false),
                    column_index = table.Column<int>(type: "integer", nullable: false),
                    row_index = table.Column<int>(type: "integer", nullable: false),
                    label = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    affiliate_store_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_mapping", x => x.id);
                    table.ForeignKey(
                        name: "fk_mapping_store",
                        column: x => x.affiliate_store_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_theme",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_theme_id_seq')"),
                    store_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    color_id = table.Column<long>(type: "bigint", maxLength: 255, nullable: false),
                    logo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cover_image = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_theme", x => x.id);
                    table.ForeignKey(
                        name: "fk_theme_color_default",
                        column: x => x.color_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_color_default",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_theme_store",
                        column: x => x.store_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_order_detail",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_order_detail_id_seq')"),
                    category_id = table.Column<string>(type: "text", nullable: true),
                    sku = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    submission_id = table.Column<long>(type: "bigint", nullable: false),
                    item_name = table.Column<string>(type: "text", nullable: true),
                    sale_price = table.Column<decimal>(type: "numeric", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_order_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_submission_order_detail",
                        column: x => x.submission_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_submission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_product",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_product_id_seq')"),
                    product_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ref_product_id = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    product_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    regular_price = table.Column<decimal>(type: "numeric", nullable: true),
                    sale_price = table.Column<decimal>(type: "numeric", nullable: true),
                    is_outof_stock = table.Column<bool>(type: "boolean", nullable: false),
                    is_stop_selling = table.Column<bool>(type: "boolean", nullable: false),
                    is_percentage = table.Column<bool>(type: "boolean", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric", nullable: true),
                    is_fixed_value = table.Column<bool>(type: "boolean", nullable: false),
                    fixed_value = table.Column<decimal>(type: "numeric", nullable: true),
                    affiliate_store_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    collection_id = table.Column<long>(type: "bigint", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_product", x => x.id);
                    table.ForeignKey(
                        name: "fk_affiliate_product_store",
                        column: x => x.affiliate_store_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_category",
                        column: x => x.category_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_product_collection",
                        column: x => x.collection_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_collection",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "affiliate_commission",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_commission_id_seq')"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    product_name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    commission_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    discount_percentage = table.Column<int>(type: "integer", nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    currency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_commission", x => x.id);
                    table.ForeignKey(
                        name: "fk_commission_product",
                        column: x => x.product_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_link",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_link_id_seq')"),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    partner_id = table.Column<long>(type: "bigint", nullable: false),
                    campaign_id = table.Column<long>(type: "bigint", nullable: true),
                    origin_link = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    target_link = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    sub_id_1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sub_id_2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sub_id_3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sub_id_4 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sub_id_5 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_link", x => x.id);
                    table.UniqueConstraint("AK_affiliate_link_tracking_id", x => x.tracking_id);
                    table.ForeignKey(
                        name: "fk_link_campaign",
                        column: x => x.campaign_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_campaign",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_link_product",
                        column: x => x.product_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "affiliate_tracking_management",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_tracking_management_id_seq')"),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    partner_id = table.Column<long>(type: "bigint", nullable: false),
                    total_clicks = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    total_hits = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_tracking_management", x => x.id);
                    table.ForeignKey(
                        name: "fk_tracking_link",
                        column: x => x.tracking_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_link",
                        principalColumn: "tracking_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tracking_product",
                        column: x => x.product_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_campaign_affiliate_store_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                column: "affiliate_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_category_affiliate_store_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_category",
                column: "affiliate_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_commission_product_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_commission",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_link_campaign_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_link",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_link_product_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_link",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_link_tracking_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_link",
                column: "tracking_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_mapping_affiliate_store_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_mapping",
                column: "affiliate_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_order_detail_submission_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_order_detail",
                column: "submission_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_product_affiliate_store_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_product",
                column: "affiliate_store_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_product_category_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_product_collection_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_product",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_theme_color_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_theme",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_theme_store_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_theme",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_tracking_management_product_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_tracking_management",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_tracking_management_tracking_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_tracking_management",
                column: "tracking_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "affiliate_business",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_click_tracking",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_commission",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_mapping",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_order_detail",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_theme",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_tracking_management",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_submission",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_color_default",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_link",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_campaign",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_product",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_category",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_collection",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_store",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_business_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_campaign_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_category_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_click_tracking_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_collection_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_color_default_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_commission_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_link_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_mapping_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_order_detail_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_partner_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_product_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_store_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_submission_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_theme_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_tracking_management_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_transaction_detail_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_transaction_id_seq",
                schema: "affiliate-tracking-services");
        }
    }
}
