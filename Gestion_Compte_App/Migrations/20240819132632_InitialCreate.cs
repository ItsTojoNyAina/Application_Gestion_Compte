using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Compte_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intervenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    QualificationBase = table.Column<string>(type: "TEXT", nullable: false),
                    QualificationIntervention = table.Column<double>(type: "REAL", nullable: false),
                    TarifJournalier = table.Column<double>(type: "REAL", nullable: false),
                    JoursHommes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervenants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervenants");
        }
    }
}
