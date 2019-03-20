using Microsoft.EntityFrameworkCore.Migrations;

namespace itsmartplus.Migrations
{
    public partial class update_CategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "br_id",
                table: "categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    br_id = table.Column<string>(nullable: false),
                    br_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.br_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_br_id",
                table: "categories",
                column: "br_id");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_brands_br_id",
                table: "categories",
                column: "br_id",
                principalTable: "brands",
                principalColumn: "br_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_brands_br_id",
                table: "categories");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropIndex(
                name: "IX_categories_br_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "br_id",
                table: "categories");
        }
    }
}
