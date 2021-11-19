using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMobileRechargeSystem.Migrations
{
    public partial class activeplanmodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activePlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RechargeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activePlans_RechargeList_RechargeId",
                        column: x => x.RechargeId,
                        principalTable: "RechargeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activePlans_RechargeId",
                table: "activePlans",
                column: "RechargeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activePlans");
        }
    }
}
