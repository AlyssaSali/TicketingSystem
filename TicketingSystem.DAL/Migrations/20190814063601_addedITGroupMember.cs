using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class addedITGroupMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITGroupMembers",
                columns: table => new
                {
                    ITGroupMemberid = table.Column<Guid>(nullable: false),
                    EmployeeID = table.Column<Guid>(nullable: false),
                    ITGroupid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITGroupMembers", x => x.ITGroupMemberid);
                    table.ForeignKey(
                        name: "FK_ITGroupMembers_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                        column: x => x.ITGroupid,
                        principalTable: "ITGroups",
                        principalColumn: "ITGroupid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITGroupMembers_EmployeeID",
                table: "ITGroupMembers",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ITGroupMembers_ITGroupid",
                table: "ITGroupMembers",
                column: "ITGroupid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITGroupMembers");
        }
    }
}
