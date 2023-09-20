using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaPimpolho.Migrations
{
    public partial class Oficinas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Oficina",
                columns: new[] { "IdOficina", "CodigoPostal", "Image", "Localidade", "Nome", "NumTelemovel" },
                values: new object[,]
                {
                    { 1001, "2835-276", "/images/id1_boxcarvulcolisboa.jpg", "Setúbal", "Auto Moderna", "911111111" },
                    { 1002, "8500-476", "/images/id10.jpg", "Faro", "Cuidado Carro", "911111112" },
                    { 1003, "7600-476", "/images/id11_corvauto.jpg", "Beja", "Espaço Car", "911111113" },
                    { 1004, "2140-476", "/images/id12.jpg", "Santarém", "Esquina da Revisão", "911111114" },
                    { 1005, "4560-476", "/images/id13_rinoauto.jpg", "Porto", "Império Car", "911111115" },
                    { 1006, "9754-476", "/images/id2_braga.jpg", "Vila Nova de Gaia", "Mecânica Vila", "911111116" },
                    { 1007, "2695-476", "/images/id3_autoarcadgua2.jpg", "Lisboa", "Mundo dos Carros", "911111117" },
                    { 1008, "6290-476", "/images/id4.jpg", "Guarda", "Prime Car", "911111118" },
                    { 1009, "3780-476", "/images/id6_meiricarro.jpg", "Aveiro", "SOS Car", "911111119" },
                    { 1010, "4740-476", "/images/id7_automotor.jpg", "Braga", "Rei da mecânica", "911111120" },
                    { 1011, "3450-476", "/images/id8.jpg", "Viseu", "Pit Stop", "911111121" },
                    { 1012, "5300-815", "/images/id9_martinho.jpg", "Bragança", "Revisa Car", "911111122" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Oficina",
                keyColumn: "IdOficina",
                keyValue: 1012);

            migrationBuilder.InsertData(
                table: "Oficina",
                columns: new[] { "IdOficina", "CodigoPostal", "Image", "Localidade", "Nome", "NumTelemovel" },
                values: new object[,]
                {
                    { 1, "2835-276", "/images/id1_boxcarvulcolisboa.jpg", "Setúbal", "Auto Moderna", "911111111" },
                    { 2, "8500-476", "/images/id10.jpg", "Faro", "Cuidado Carro", "911111112" },
                    { 3, "7600-476", "/images/id11_corvauto.jpg", "Beja", "Espaço Car", "911111113" },
                    { 4, "2140-476", "/images/id12.jpg", "Santarém", "Esquina da Revisão", "911111114" },
                    { 5, "4560-476", "/images/id13_rinoauto.jpg", "Porto", "Império Car", "911111115" },
                    { 6, "9754-476", "/images/id2_braga.jpg", "Vila Nova de Gaia", "Mecânica Vila", "911111116" },
                    { 7, "2695-476", "/images/id3_autoarcadgua2.jpg", "Lisboa", "Mundo dos Carros", "911111117" },
                    { 8, "6290-476", "/images/id4.jpg", "Guarda", "Prime Car", "911111118" },
                    { 9, "3780-476", "/images/id6_meiricarro.jpg", "Aveiro", "SOS Car", "911111119" },
                    { 10, "4740-476", "/images/id7_automotor.jpg", "Braga", "Rei da mecânica", "911111120" },
                    { 11, "3450-476", "/images/id8.jpg", "Viseu", "Pit Stop", "911111121" },
                    { 12, "5300-815", "/images/id9_martinho.jpg", "Bragança", "Revisa Car", "911111122" }
                });
        }
    }
}
