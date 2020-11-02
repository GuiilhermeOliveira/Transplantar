using Microsoft.EntityFrameworkCore.Migrations;

namespace Transplantar.Migrations
{
    public partial class Transplantar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Pin = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Celular = table.Column<string>(maxLength: 30, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 20, nullable: false),
                    Orgao = table.Column<string>(nullable: false),
                    GrupoSanguineo = table.Column<string>(nullable: false),
                    TipoUsuario = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
