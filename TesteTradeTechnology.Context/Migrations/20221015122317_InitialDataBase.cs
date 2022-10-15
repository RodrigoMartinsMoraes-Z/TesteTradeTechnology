using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteTradeTechnology.Context.Migrations
{
    public partial class InitialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTimeA = table.Column<int>(type: "integer", nullable: false),
                    IdTimeB = table.Column<int>(type: "integer", nullable: false),
                    PontosTimeA = table.Column<int>(type: "integer", nullable: false),
                    PontosTimeB = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placares_Times_IdTimeA",
                        column: x => x.IdTimeA,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placares_Times_IdTimeB",
                        column: x => x.IdTimeB,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPlacar = table.Column<int>(type: "integer", nullable: false),
                    IdCampeonato = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Campeonatos_IdCampeonato",
                        column: x => x.IdCampeonato,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_Placares_IdPlacar",
                        column: x => x.IdPlacar,
                        principalTable: "Placares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Time1" },
                    { 2, "Time2" },
                    { 3, "Time3" },
                    { 4, "Time4" },
                    { 5, "Time5" },
                    { 6, "Time6" },
                    { 7, "Time7" },
                    { 8, "Time8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_IdCampeonato",
                table: "Jogos",
                column: "IdCampeonato");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_IdPlacar",
                table: "Jogos",
                column: "IdPlacar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placares_IdTimeA",
                table: "Placares",
                column: "IdTimeA");

            migrationBuilder.CreateIndex(
                name: "IX_Placares_IdTimeB",
                table: "Placares",
                column: "IdTimeB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "Placares");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
