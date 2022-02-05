using Microsoft.EntityFrameworkCore.Migrations;

namespace Trouvtou.Migrations
{
    public partial class VersionFinale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    estConnecte = table.Column<bool>(type: "INTEGER", nullable: false),
                    mdp = table.Column<string>(type: "TEXT", nullable: true),
                    pseudo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.id);
                });
        }
    }
}
