using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillApp2.Migrations
{
    public partial class bill2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Bireysel_BireyselidNum",
                table: "Fatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Kurumsal_KurumsalkurumId",
                table: "Fatura");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_BireyselidNum",
                table: "Fatura");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_KurumsalkurumId",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "BireyselidNum",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "KurumsalkurumId",
                table: "Fatura");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_kurumId",
                table: "Fatura",
                column: "kurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_userId",
                table: "Fatura",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Bireysel_userId",
                table: "Fatura",
                column: "userId",
                principalTable: "Bireysel",
                principalColumn: "idNum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Kurumsal_kurumId",
                table: "Fatura",
                column: "kurumId",
                principalTable: "Kurumsal",
                principalColumn: "kurumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Bireysel_userId",
                table: "Fatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatura_Kurumsal_kurumId",
                table: "Fatura");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_kurumId",
                table: "Fatura");

            migrationBuilder.DropIndex(
                name: "IX_Fatura_userId",
                table: "Fatura");

            migrationBuilder.AddColumn<int>(
                name: "BireyselidNum",
                table: "Fatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KurumsalkurumId",
                table: "Fatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_BireyselidNum",
                table: "Fatura",
                column: "BireyselidNum");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_KurumsalkurumId",
                table: "Fatura",
                column: "KurumsalkurumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Bireysel_BireyselidNum",
                table: "Fatura",
                column: "BireyselidNum",
                principalTable: "Bireysel",
                principalColumn: "idNum",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatura_Kurumsal_KurumsalkurumId",
                table: "Fatura",
                column: "KurumsalkurumId",
                principalTable: "Kurumsal",
                principalColumn: "kurumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
