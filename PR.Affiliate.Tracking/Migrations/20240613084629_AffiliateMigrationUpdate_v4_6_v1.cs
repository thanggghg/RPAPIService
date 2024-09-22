using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSell.Affiliate.Tracking.Migrations
{
    /// <inheritdoc />
    public partial class AffiliateMigrationUpdate_v4_6_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_affiliate_store_affiliate_business_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropIndex(
                name: "IX_affiliate_store_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.AlterColumn<DateTime>(
                name: "order_created_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterSequence(
                name: "affiliate_color_default_id_seq",
                schema: "affiliate-tracking-services",
                oldMinValue: 1L,
                oldMaxValue: 9223372036854775807L);

            migrationBuilder.AlterSequence(
                name: "affiliate_business_id_seq",
                schema: "affiliate-tracking-services",
                oldMinValue: 1L,
                oldMaxValue: 9223372036854775807L);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_store_business_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "business_id");

            migrationBuilder.AddForeignKey(
                name: "fk_store_business",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "business_id",
                principalSchema: "affiliate-tracking-services",
                principalTable: "affiliate_business",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_store_business",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropIndex(
                name: "IX_affiliate_store_business_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "order_created_date",
                schema: "affiliate-tracking-services",
                table: "affiliate_submission",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<long>(
                name: "AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterSequence(
                name: "affiliate_color_default_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.AlterSequence(
                name: "affiliate_business_id_seq",
                schema: "affiliate-tracking-services",
                minValue: 1L,
                maxValue: 9223372036854775807L);

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_store_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "AffiliateBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_affiliate_store_affiliate_business_AffiliateBusinessId",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "AffiliateBusinessId",
                principalSchema: "affiliate-tracking-services",
                principalTable: "affiliate_business",
                principalColumn: "id");
        }
    }
}
