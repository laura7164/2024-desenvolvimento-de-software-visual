using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Folhas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "FuncionarioId");

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    FolhaPagamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioBruto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.FolhaPagamentoId);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "FuncionarioId");
        }
    }
}
