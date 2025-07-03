using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillApp2.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bireysel",
                columns: table => new
                {
                    idNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parola = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bireysel", x => x.idNum);
                });

            migrationBuilder.CreateTable(
                name: "Kurumsal",
                columns: table => new
                {
                    kurumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kurumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurumsal", x => x.kurumId);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    faturaNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BireyselidNum = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    KurumsalkurumId = table.Column<int>(type: "int", nullable: false),
                    kurumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.faturaNo);
                    table.ForeignKey(
                        name: "FK_Fatura_Bireysel_BireyselidNum",
                        column: x => x.BireyselidNum,
                        principalTable: "Bireysel",
                        principalColumn: "idNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fatura_Kurumsal_KurumsalkurumId",
                        column: x => x.KurumsalkurumId,
                        principalTable: "Kurumsal",
                        principalColumn: "kurumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdenmisFatura",
                columns: table => new
                {
                    odemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faturaNo = table.Column<int>(type: "int", nullable: true),
                    idNum = table.Column<int>(type: "int", nullable: false),
                    odenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    odenenMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdenmisFatura", x => x.odemeId);
                    table.ForeignKey(
                        name: "FK_OdenmisFatura_Bireysel_idNum",
                        column: x => x.idNum,
                        principalTable: "Bireysel",
                        principalColumn: "idNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdenmisFatura_Fatura_faturaNo",
                        column: x => x.faturaNo,
                        principalTable: "Fatura",
                        principalColumn: "faturaNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_BireyselidNum",
                table: "Fatura",
                column: "BireyselidNum");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_KurumsalkurumId",
                table: "Fatura",
                column: "KurumsalkurumId");

            migrationBuilder.CreateIndex(
                name: "IX_OdenmisFatura_faturaNo",
                table: "OdenmisFatura",
                column: "faturaNo");

            migrationBuilder.CreateIndex(
                name: "IX_OdenmisFatura_idNum",
                table: "OdenmisFatura",
                column: "idNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdenmisFatura");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Bireysel");

            migrationBuilder.DropTable(
                name: "Kurumsal");
        }
    }
}
