using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaPimpolho.Migrations
{
    public partial class Oficinas5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcacaoServico_Marcacao_MarcacaoId",
                table: "MarcacaoServico");

            migrationBuilder.DropForeignKey(
                name: "FK_MarcacaoServico_Servico_ServicoId",
                table: "MarcacaoServico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcacaoServico",
                table: "MarcacaoServico");

            migrationBuilder.RenameTable(
                name: "MarcacaoServico",
                newName: "MarcacaoServicos");

            migrationBuilder.RenameIndex(
                name: "IX_MarcacaoServico_ServicoId",
                table: "MarcacaoServicos",
                newName: "IX_MarcacaoServicos_ServicoId");

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "Oficina",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcacaoServicos",
                table: "MarcacaoServicos",
                columns: new[] { "MarcacaoId", "ServicoId" });

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1001,
                column: "Morada",
                value: "Rua da Oficina, 123");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1002,
                column: "Morada",
                value: "Avenida dos Reparos, 456");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1003,
                column: "Morada",
                value: "Rua das Ferramentas, 789");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1004,
                column: "Morada",
                value: "Travessa dos Motores, 234");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1005,
                column: "Morada",
                value: "Largo das Revisões, 567");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1006,
                column: "Morada",
                value: "Praça das Soldaduras, 890");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1007,
                column: "Morada",
                value: "Rua das Pinturas, 345");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1008,
                column: "Morada",
                value: "Avenida dos Veículos, 678");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1009,
                column: "Morada",
                value: "Rua dos Mecânicos, 901");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1010,
                column: "Morada",
                value: "Travessa das Baterias, 234");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1011,
                column: "Morada",
                value: "Avenida das Transmissões, 567");

            migrationBuilder.UpdateData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1012,
                column: "Morada",
                value: "Rua das Engrenagens, 890");

            migrationBuilder.AddForeignKey(
                name: "FK_MarcacaoServicos_Marcacao_MarcacaoId",
                table: "MarcacaoServicos",
                column: "MarcacaoId",
                principalTable: "Marcacao",
                principalColumn: "IdMarcacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarcacaoServicos_Servico_ServicoId",
                table: "MarcacaoServicos",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcacaoServicos_Marcacao_MarcacaoId",
                table: "MarcacaoServicos");

            migrationBuilder.DropForeignKey(
                name: "FK_MarcacaoServicos_Servico_ServicoId",
                table: "MarcacaoServicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarcacaoServicos",
                table: "MarcacaoServicos");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "Oficina");

            migrationBuilder.RenameTable(
                name: "MarcacaoServicos",
                newName: "MarcacaoServico");

            migrationBuilder.RenameIndex(
                name: "IX_MarcacaoServicos_ServicoId",
                table: "MarcacaoServico",
                newName: "IX_MarcacaoServico_ServicoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarcacaoServico",
                table: "MarcacaoServico",
                columns: new[] { "MarcacaoId", "ServicoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MarcacaoServico_Marcacao_MarcacaoId",
                table: "MarcacaoServico",
                column: "MarcacaoId",
                principalTable: "Marcacao",
                principalColumn: "IdMarcacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarcacaoServico_Servico_ServicoId",
                table: "MarcacaoServico",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
