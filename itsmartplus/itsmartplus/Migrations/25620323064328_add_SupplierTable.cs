using Microsoft.EntityFrameworkCore.Migrations;

namespace itsmartplus.Migrations
{
    public partial class add_SupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    supp_id = table.Column<string>(nullable: false),
                    supp_name = table.Column<string>(nullable: true),
                    supp_addr = table.Column<string>(maxLength: 255, nullable: true),
                    supp_phone = table.Column<string>(nullable: true),
                    supp_mobile = table.Column<string>(nullable: true),
                    supp_mail = table.Column<string>(nullable: true),
                    supp_fax = table.Column<string>(nullable: true),
                    supp_tin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.supp_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
