using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace itsmartplus.Migrations
{
    public partial class add_pm_category_pm_category_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pm_Categories",
                columns: table => new
                {
                    pm_genid = table.Column<string>(nullable: false),
                    pm_date = table.Column<DateTime>(nullable: false),
                    ad_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pm_Categories", x => x.pm_genid);
                    table.ForeignKey(
                        name: "FK_pm_Categories_admintables_ad_id",
                        column: x => x.ad_id,
                        principalTable: "admintables",
                        principalColumn: "ad_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pm_Categories_details",
                columns: table => new
                {
                    pm_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pmdetail = table.Column<string>(maxLength: 100, nullable: true),
                    pm_normal = table.Column<bool>(nullable: false),
                    pm_update = table.Column<bool>(nullable: false),
                    pm_repair = table.Column<bool>(nullable: false),
                    pm_spare = table.Column<bool>(nullable: false),
                    pm_equip = table.Column<bool>(nullable: false),
                    remark = table.Column<string>(maxLength: 250, nullable: true),
                    pm_genid = table.Column<string>(nullable: true),
                    cat_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pm_Categories_details", x => x.pm_id);
                    table.ForeignKey(
                        name: "FK_pm_Categories_details_categories_cat_id",
                        column: x => x.cat_id,
                        principalTable: "categories",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pm_Categories_details_pm_Categories_pm_genid",
                        column: x => x.pm_genid,
                        principalTable: "pm_Categories",
                        principalColumn: "pm_genid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pm_Categories_ad_id",
                table: "pm_Categories",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_pm_Categories_details_cat_id",
                table: "pm_Categories_details",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_pm_Categories_details_pm_genid",
                table: "pm_Categories_details",
                column: "pm_genid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pm_Categories_details");

            migrationBuilder.DropTable(
                name: "pm_Categories");
        }
    }
}
