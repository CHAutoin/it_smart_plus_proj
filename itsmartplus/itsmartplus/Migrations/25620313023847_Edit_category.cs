using Microsoft.EntityFrameworkCore.Migrations;

namespace itsmartplus.Migrations
{
    public partial class Edit_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cat_brand",
                table: "categories");

            migrationBuilder.AlterColumn<string>(
                name: "cat_models",
                table: "categories",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cat_models",
                table: "categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "cat_brand",
                table: "categories",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
