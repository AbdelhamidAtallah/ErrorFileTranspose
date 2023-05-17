using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErrorTranspose.Migrations
{
    /// <inheritdoc />
    public partial class Error : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeModification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureErreur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeErreur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureErreur2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeErreur2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureErreur3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeErreur3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureErreur4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeErreur4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarques = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ErrorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");
        }
    }
}
