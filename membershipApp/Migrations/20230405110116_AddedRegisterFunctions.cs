using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace membershipApp.Migrations
{
    public partial class AddedRegisterFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
