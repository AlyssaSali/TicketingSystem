using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class addedEmployeetoOfficeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Office",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "Officeid",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Officeid",
                table: "Employees",
                column: "Officeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Officeid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Officeid",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Office",
                table: "Employees",
                nullable: true);
        }
    }
}
