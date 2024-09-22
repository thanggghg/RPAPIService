using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoSell.Affiliate.Tracking.Migrations
{
    /// <inheritdoc />
    public partial class affiliate_store_currency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "affiliate_store_currency_id_seq",
                schema: "affiliate-tracking-services");

            migrationBuilder.AddColumn<long>(
                name: "affiliate_store_currency_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "affiliate_store_currency",
                schema: "affiliate-tracking-services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval('\"affiliate-tracking-services\".affiliate_store_currency_id_seq')"),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    symbol = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    last_modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true, defaultValueSql: "now()"),
                    last_modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliate_store_currency", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_affiliate_store_affiliate_store_currency_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "affiliate_store_currency_id");

            migrationBuilder.AddForeignKey(
                name: "FK_affiliate_store_affiliate_store_currency_affiliate_store_cu~",
                schema: "affiliate-tracking-services",
                table: "affiliate_store",
                column: "affiliate_store_currency_id",
                principalSchema: "affiliate-tracking-services",
                principalTable: "affiliate_store_currency",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_affiliate_store_affiliate_store_currency_affiliate_store_cu~",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropTable(
                name: "affiliate_store_currency",
                schema: "affiliate-tracking-services");

            migrationBuilder.DropIndex(
                name: "IX_affiliate_store_affiliate_store_currency_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropColumn(
                name: "affiliate_store_currency_id",
                schema: "affiliate-tracking-services",
                table: "affiliate_store");

            migrationBuilder.DropSequence(
                name: "affiliate_store_currency_id_seq",
                schema: "affiliate-tracking-services");
        }
    }
}
