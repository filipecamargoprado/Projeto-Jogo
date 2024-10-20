using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoJogo.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Escolha_Jogadores_JogadorId",
                table: "Escolha");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_FinalJogo_FinalJogoId",
                table: "Jogadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalJogo",
                table: "FinalJogo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escolha",
                table: "Escolha");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogadores");

            migrationBuilder.RenameTable(
                name: "FinalJogo",
                newName: "Finais");

            migrationBuilder.RenameTable(
                name: "Escolha",
                newName: "Escolhas");

            migrationBuilder.RenameIndex(
                name: "IX_Escolha_JogadorId",
                table: "Escolhas",
                newName: "IX_Escolhas_JogadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finais",
                table: "Finais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escolhas",
                table: "Escolhas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Finais",
                columns: new[] { "Id", "TipoFinal" },
                values: new object[,]
                {
                    { 1, "Final Indefinido" },
                    { 2, "Final Bom" },
                    { 3, "Final Ruim" },
                    { 4, "Morte" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Escolhas_Jogadores_JogadorId",
                table: "Escolhas",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Finais_FinalJogoId",
                table: "Jogadores",
                column: "FinalJogoId",
                principalTable: "Finais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Escolhas_Jogadores_JogadorId",
                table: "Escolhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Finais_FinalJogoId",
                table: "Jogadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finais",
                table: "Finais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escolhas",
                table: "Escolhas");

            migrationBuilder.DeleteData(
                table: "Finais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Finais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Finais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Finais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Finais",
                newName: "FinalJogo");

            migrationBuilder.RenameTable(
                name: "Escolhas",
                newName: "Escolha");

            migrationBuilder.RenameIndex(
                name: "IX_Escolhas_JogadorId",
                table: "Escolha",
                newName: "IX_Escolha_JogadorId");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogadores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalJogo",
                table: "FinalJogo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escolha",
                table: "Escolha",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Escolha_Jogadores_JogadorId",
                table: "Escolha",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_FinalJogo_FinalJogoId",
                table: "Jogadores",
                column: "FinalJogoId",
                principalTable: "FinalJogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
