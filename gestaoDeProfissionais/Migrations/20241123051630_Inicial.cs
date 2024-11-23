using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestaoDeProfissionais.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissionais_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 1, "Cardiologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 2, "Nutricionista Clínico", "CRN" });

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_EspecialidadeId",
                table: "Profissionais",
                column: "EspecialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
