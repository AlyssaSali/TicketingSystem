using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class addedGroupEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITGroupMembers_Employees_EmployeeID",
                table: "ITGroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_ITGroupMembers_EmployeeID",
                table: "ITGroupMembers");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "ITGroupMembers");

            migrationBuilder.CreateTable(
                name: "GroupEmployees",
                columns: table => new
                {
                    GroupEmployeeid = table.Column<Guid>(nullable: false),
                    EmployeeID = table.Column<Guid>(nullable: false),
                    EmployeeFullName = table.Column<string>(nullable: true),
                    ITGroupMemberid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEmployees", x => x.GroupEmployeeid);
                    table.ForeignKey(
                        name: "FK_GroupEmployees_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                        column: x => x.ITGroupMemberid,
                        principalTable: "ITGroupMembers",
                        principalColumn: "ITGroupMemberid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmployees_EmployeeID",
                table: "GroupEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmployees_ITGroupMemberid",
                table: "GroupEmployees",
                column: "ITGroupMemberid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEmployees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "ITGroupMembers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ITGroupMembers_EmployeeID",
                table: "ITGroupMembers",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ITGroupMembers_Employees_EmployeeID",
                table: "ITGroupMembers",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
