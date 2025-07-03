using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillApp2.Migrations
{
    public partial class bill4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Kurumsal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Kurumsal",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Kurumsal");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Kurumsal");
        }
    }
}
