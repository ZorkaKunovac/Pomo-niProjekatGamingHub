using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomoćniProjekatGamingHub.Migrations
{
    public partial class InicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konzola",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Proizvodjac = table.Column<string>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: false),
                    Detalji = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konzola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeProizvoda = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    NabavnaCijena = table.Column<int>(nullable: false),
                    ProdajnaCijena = table.Column<int>(nullable: false),
                    Popust = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zarn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 100, nullable: true),
                    Opis = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zarn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Igra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Developer = table.Column<string>(nullable: true),
                    Izdavac = table.Column<string>(nullable: true),
                    DatumIzlaska = table.Column<DateTime>(nullable: true),
                    VideoLink = table.Column<string>(maxLength: 100, nullable: true),
                    SlikaLink = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igra_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKorisnikaId = table.Column<int>(nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: true),
                    Lozinka = table.Column<string>(maxLength: 100, nullable: true),
                    Ime = table.Column<string>(maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Spol = table.Column<string>(maxLength: 10, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: true),
                    Verifikovan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_TipKorisnika_TipKorisnikaId",
                        column: x => x.TipKorisnikaId,
                        principalTable: "TipKorisnika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IgraKonzola",
                columns: table => new
                {
                    IgraID = table.Column<int>(nullable: false),
                    KonzolaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgraKonzola", x => new { x.IgraID, x.KonzolaID });
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Igra_IgraID",
                        column: x => x.IgraID,
                        principalTable: "Igra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IgraKonzola_Konzola_KonzolaID",
                        column: x => x.KonzolaID,
                        principalTable: "Konzola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IgraZarn",
                columns: table => new
                {
                    IgraID = table.Column<int>(nullable: false),
                    ZarnID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgraZarn", x => new { x.IgraID, x.ZarnID });
                    table.ForeignKey(
                        name: "FK_IgraZarn_Igra_IgraID",
                        column: x => x.IgraID,
                        principalTable: "Igra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IgraZarn_Zarn_ZarnID",
                        column: x => x.ZarnID,
                        principalTable: "Zarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(maxLength: 250, nullable: true),
                    DatumKreiranja = table.Column<DateTime>(nullable: true),
                    Sadrzaj = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RecenzijaZarn",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(nullable: false),
                    ZarnID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecenzijaZarn", x => new { x.RecenzijaID, x.ZarnID });
                    table.ForeignKey(
                        name: "FK_RecenzijaZarn_Recenzija_RecenzijaID",
                        column: x => x.RecenzijaID,
                        principalTable: "Recenzija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecenzijaZarn_Zarn_ZarnID",
                        column: x => x.ZarnID,
                        principalTable: "Zarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igra_ProizvodID",
                table: "Igra",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraKonzola_KonzolaID",
                table: "IgraKonzola",
                column: "KonzolaID");

            migrationBuilder.CreateIndex(
                name: "IX_IgraZarn_ZarnID",
                table: "IgraZarn",
                column: "ZarnID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_TipKorisnikaId",
                table: "Korisnik",
                column: "TipKorisnikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KorisnikId",
                table: "Recenzija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_RecenzijaZarn_ZarnID",
                table: "RecenzijaZarn",
                column: "ZarnID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IgraKonzola");

            migrationBuilder.DropTable(
                name: "IgraZarn");

            migrationBuilder.DropTable(
                name: "RecenzijaZarn");

            migrationBuilder.DropTable(
                name: "Konzola");

            migrationBuilder.DropTable(
                name: "Igra");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Zarn");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "TipKorisnika");
        }
    }
}
