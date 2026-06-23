using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternApi.Migrations
{
    /// <inheritdoc />
    public partial class InitinalCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Localidade = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Uf = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SalvoEmCache = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
