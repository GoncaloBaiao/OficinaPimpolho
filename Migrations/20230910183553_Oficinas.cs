using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaPimpolho.Migrations
{
    public partial class Oficinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gestor",
                keyColumn: "IdGestor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gestor",
                keyColumn: "IdGestor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gestor",
                keyColumn: "IdGestor",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gestor",
                columns: new[] { "IdGestor", "Email", "Nome", "Ntelemovel", "OficinaId" },
                values: new object[] { 1, "celeste@gmail.com", "Guita Pimpolho", "911111111", 1 });

            migrationBuilder.InsertData(
                table: "Gestor",
                columns: new[] { "IdGestor", "Email", "Nome", "Ntelemovel", "OficinaId" },
                values: new object[] { 2, "sarabatista@gmail.com", "Carlos Ribeiro", "911111112", 2 });

            migrationBuilder.InsertData(
                table: "Gestor",
                columns: new[] { "IdGestor", "Email", "Nome", "Ntelemovel", "OficinaId" },
                values: new object[] { 3, "tinoni@gmail.com", "Joaquim Alberto", "911111113", 3 });
        }
    }
}
