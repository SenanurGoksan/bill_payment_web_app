using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillApp2.Migrations
{
    public partial class bill3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Bireysel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Bireysel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Bireysel");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Bireysel");
        }
    }
}
