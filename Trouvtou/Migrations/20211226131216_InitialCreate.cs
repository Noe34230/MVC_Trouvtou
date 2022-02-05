using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trouvtou.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rangement",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    couleur = table.Column<string>(type: "TEXT", nullable: false),
                    descriptionDetail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rangement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Objet",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    typeObjet = table.Column<string>(type: "TEXT", nullable: false),
                    estConsultable = table.Column<bool>(type: "INTEGER", nullable: false),
                    dateDernierRangement = table.Column<DateTime>(type: "TEXT", nullable: false),
                    rangementid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objet", x => x.id);
                    table.ForeignKey(
                        name: "FK_Objet_Rangement_rangementid",
                        column: x => x.rangementid,
                        principalTable: "Rangement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objet_rangementid",
                table: "Objet",
                column: "rangementid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objet");

            migrationBuilder.DropTable(
                name: "Rangement");
        }
    }
}
