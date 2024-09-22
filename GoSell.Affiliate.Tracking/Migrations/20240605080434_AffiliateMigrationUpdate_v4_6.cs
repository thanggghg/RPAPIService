using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSell.Affiliate.Tracking.Migrations
{
    /// <inheritdoc />
    public partial class AffiliateMigrationUpdate_v4_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "affiliate_campaign_product_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.CreateSequence(
                name: "affiliate_order_tracking_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "partner_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "allow_get_order_tracking",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "allow_get_order_tracking_code",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "allow_get_order_tracking_url",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "key_word_by_code",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "key_word_by_url",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "partner_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_commission",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now() at time zone 'utc'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "now()");

            migrationBuilder.AddColumn<string>(
                name: "note",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "terminated_by",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "terminated_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "affiliate_campaign_product",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_campaign_product_id_seq')"),
                    affiliate_campaign_id = table.Column<long>(type: "bigint", nullable: false),
                    affiliate_product_id = table.Column<long>(type: "bigint", nullable: false),
                    commission_percent = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    commission_fix = table.Column<decimal>(type: "numeric(20,2)", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_campaign_product", x => x.id);
                    table.ForeignKey(
                        name: "fk_affiliate_campaign_id",
                        column: x => x.affiliate_campaign_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_affiliate_product_id",
                        column: x => x.affiliate_product_id,
                        principalSchema: "affiliate-tracking-services",
                        principalTable: "affiliate_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliate_order_tracking",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_order_tracking_id_seq')"),
                    order_id = table.Column<string>(type: "text", nullable: false),
                    tracking_ids = table.Column<string>(type: "text", nullable: false),
                    website = table.Column<string>(type: "text", nullable: false),
                    order_create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_order_tracking", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_store_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "AffiliateBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_campaign_product_affiliate_campaign_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign_product",
                column: "affiliate_campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_campaign_product_affiliate_product_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign_product",
                column: "affiliate_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_affiliate_store_affiliate_business_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "AffiliateBusinessId",
                principalSchema: "affiliate-tracking-services",
                principalTable: "affiliate_business",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_affiliate_store_affiliate_business_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropTable(
                name: "affiliate_campaign_product",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropTable(
                name: "affiliate_order_tracking",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropIndex(
                name: "IX_affiliate_store_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "partner_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission");

            migrationBuilder.DropColumn(
                name: "AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "allow_get_order_tracking",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "allow_get_order_tracking_code",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "allow_get_order_tracking_url",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "key_word_by_code",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "key_word_by_url",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "partner_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_commission");

            migrationBuilder.DropColumn(
                name: "note",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign");

            migrationBuilder.DropColumn(
                name: "terminated_by",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign");

            migrationBuilder.DropColumn(
                name: "terminated_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign");

            migrationBuilder.DropSequence(
                name: "affiliate_campaign_product_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropSequence(
                name: "affiliate_order_tracking_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.AlterColumn<int>(
                name: "payment_method",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_campaign",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "now() at time zone 'utc'");
        }
    }
}
