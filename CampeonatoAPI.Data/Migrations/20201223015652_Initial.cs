using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 1000, nullable: true),
                    CodigoCampeonato = table.Column<string>(nullable: true),
                    CampeaoId = table.Column<Guid>(nullable: true),
                    ViciId = table.Column<Guid>(nullable: true),
                    TerceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_CampeaoId",
                        column: x => x.CampeaoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_TerceiroId",
                        column: x => x.TerceiroId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_ViciId",
                        column: x => x.ViciId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontuacaoCampeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    TimeId = table.Column<Guid>(nullable: true),
                    CodigoCampeonato = table.Column<string>(nullable: true),
                    PontuacaoTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontuacaoCampeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    TimeAId = table.Column<Guid>(nullable: true),
                    GolsA = table.Column<int>(nullable: false),
                    TimeBId = table.Column<Guid>(nullable: true),
                    GolsB = table.Column<int>(nullable: false),
                    CodigoCampeonato = table.Column<string>(nullable: true),
                    CampeonatoEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Campeonato_CampeonatoEntityId",
                        column: x => x.CampeonatoEntityId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_TimeAId",
                        column: x => x.TimeAId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_TimeBId",
                        column: x => x.TimeBId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Campeonato_CampeaoId",
                table: "Campeonato",
                column: "CampeaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_CodigoCampeonato",
                table: "Campeonato",
                column: "CodigoCampeonato",
                unique: true,
                filter: "[CodigoCampeonato] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_TerceiroId",
                table: "Campeonato",
                column: "TerceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_ViciId",
                table: "Campeonato",
                column: "ViciId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CampeonatoEntityId",
                table: "Partida",
                column: "CampeonatoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeAId",
                table: "Partida",
                column: "TimeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeBId",
                table: "Partida",
                column: "TimeBId");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_TimeId",
                table: "PontuacaoCampeonato",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_Nome",
                table: "Time",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "PontuacaoCampeonato");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
