using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoAPI.Data.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Campeonato_CodigoCampeonato",
                table: "Campeonato");

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("4052aac6-8580-4d96-ac8e-fc6e0211a173"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("672e7116-3374-48dc-b2e6-224bb0fcdb2c"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("b0372680-0183-4392-88af-5ca2bcb84dd1"));

            migrationBuilder.DropColumn(
                name: "CodigoCampeonato",
                table: "Campeonato");

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("c39d67c2-511c-4d6a-98ff-064cd30f733e"), null, "São Paulo", null, false });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("b763e22d-f625-42fa-9020-ab0d8b07283f"), null, "Flamengo", null, false });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("482b119e-bd66-4892-8d64-b6a9063f7bdf"), null, "Corinthians", null, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("482b119e-bd66-4892-8d64-b6a9063f7bdf"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("b763e22d-f625-42fa-9020-ab0d8b07283f"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("c39d67c2-511c-4d6a-98ff-064cd30f733e"));

            migrationBuilder.AddColumn<string>(
                name: "CodigoCampeonato",
                table: "Campeonato",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("4052aac6-8580-4d96-ac8e-fc6e0211a173"), null, "São Paulo", null, false });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("672e7116-3374-48dc-b2e6-224bb0fcdb2c"), null, "Flamengo", null, false });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt", "isDeleted" },
                values: new object[] { new Guid("b0372680-0183-4392-88af-5ca2bcb84dd1"), null, "Corinthians", null, false });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_CodigoCampeonato",
                table: "Campeonato",
                column: "CodigoCampeonato",
                unique: true,
                filter: "[CodigoCampeonato] IS NOT NULL");
        }
    }
}
