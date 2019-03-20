using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace itsmartplus.Migrations
{
    public partial class addthreetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "t_name",
                table: "types",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "admintables",
                columns: table => new
                {
                    ad_id = table.Column<string>(maxLength: 10, nullable: false),
                    ad_pass = table.Column<string>(maxLength: 50, nullable: false),
                    ad_name = table.Column<string>(maxLength: 50, nullable: false),
                    ad_lastname = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admintables", x => x.ad_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    em_id = table.Column<string>(maxLength: 10, nullable: false),
                    em_name = table.Column<string>(maxLength: 50, nullable: false),
                    em_lastname = table.Column<string>(maxLength: 50, nullable: false),
                    em_img = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.em_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    cat_id = table.Column<string>(maxLength: 10, nullable: false),
                    cat_brand = table.Column<string>(maxLength: 10, nullable: false),
                    cat_models = table.Column<string>(nullable: true),
                    cat_image = table.Column<byte[]>(nullable: true),
                    t_id = table.Column<string>(nullable: true),
                    em_id = table.Column<string>(nullable: true),
                    ad_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.cat_id);
                    table.ForeignKey(
                        name: "FK_categories_admintables_ad_id",
                        column: x => x.ad_id,
                        principalTable: "admintables",
                        principalColumn: "ad_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_categories_employees_em_id",
                        column: x => x.em_id,
                        principalTable: "employees",
                        principalColumn: "em_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_categories_types_t_id",
                        column: x => x.t_id,
                        principalTable: "types",
                        principalColumn: "t_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_ad_id",
                table: "categories",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_em_id",
                table: "categories",
                column: "em_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_t_id",
                table: "categories",
                column: "t_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "admintables");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.AlterColumn<string>(
                name: "t_name",
                table: "types",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
