using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherApplication.Api.Migrations
{
    public partial class AddTemperatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    StationId = table.Column<string>(nullable: false),
                    AirTemperature = table.Column<double>(nullable: false),
                    Quality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => new { x.Date, x.StationId });
                    table.ForeignKey(
                        name: "FK_Temperatures_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_StationId",
                table: "Temperatures",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatures");
        }
    }
}
