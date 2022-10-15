using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senfoni.Data.Migrations
{
    public partial class sipairissfdvksfv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Kod = table.Column<string>(nullable: true),
                    CariId = table.Column<long>(nullable: false),
                    KullaniciId = table.Column<string>(nullable: true),
                    SiparisTarihi = table.Column<DateTime>(nullable: false),
                    TeslimTarihi = table.Column<DateTime>(nullable: false),
                    Kapandi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_CariId",
                table: "Siparis",
                column: "CariId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "SiparisBilgileri");

            migrationBuilder.DropTable(
                name: "TeklifBilgileri");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "Teklif");

            migrationBuilder.DropTable(
                name: "Cari");
        }
    }
}
