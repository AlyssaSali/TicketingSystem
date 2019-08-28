using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class AddedEmployeeEmployeeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_Categories_Categoryid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_ITGroups_ITGroupid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_Severities_Severityid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEmployees_Employees_EmployeeID",
                table: "GroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                table: "GroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                table: "ITGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_CategoryLists_CategoryListid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_Offices_Officeid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_Employees_Requesterid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CategoryLists_CategoryListid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ITGroups_ITGroupid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Offices_Officeid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_Users_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.CreateTable(
                name: "EmployeeEmployeeTypes",
                columns: table => new
                {
                    EmployeeEmployeeTypeid = table.Column<Guid>(nullable: false),
                    EmployeeTypeid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployeeTypes", x => x.EmployeeEmployeeTypeid);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployeeTypes_EmployeeTypes_EmployeeTypeid",
                        column: x => x.EmployeeTypeid,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeEmployees",
                columns: table => new
                {
                    TypeEmployeeid = table.Column<Guid>(nullable: false),
                    EmployeeID = table.Column<Guid>(nullable: false),
                    EmployeeFullName = table.Column<string>(nullable: true),
                    EmployeeEmployeeTypeid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEmployees", x => x.TypeEmployeeid);
                    table.ForeignKey(
                        name: "FK_TypeEmployees_EmployeeEmployeeTypes_EmployeeEmployeeTypeid",
                        column: x => x.EmployeeEmployeeTypeid,
                        principalTable: "EmployeeEmployeeTypes",
                        principalColumn: "EmployeeEmployeeTypeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeEmployees_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployeeTypes_EmployeeTypeid",
                table: "EmployeeEmployeeTypes",
                column: "EmployeeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEmployees_EmployeeEmployeeTypeid",
                table: "TypeEmployees",
                column: "EmployeeEmployeeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEmployees_EmployeeID",
                table: "TypeEmployees",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_Categories_Categoryid",
                table: "CategoryLists",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "Categoryid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_ITGroups_ITGroupid",
                table: "CategoryLists",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_Severities_Severityid",
                table: "CategoryLists",
                column: "Severityid",
                principalTable: "Severities",
                principalColumn: "Severityid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeid",
                table: "Employees",
                column: "EmployeeTypeid",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEmployees_Employees_EmployeeID",
                table: "GroupEmployees",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                table: "GroupEmployees",
                column: "ITGroupMemberid",
                principalTable: "ITGroupMembers",
                principalColumn: "ITGroupMemberid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                table: "ITGroupMembers",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_CategoryLists_CategoryListid",
                table: "TicketMinors",
                column: "CategoryListid",
                principalTable: "CategoryLists",
                principalColumn: "CategoryListid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_Offices_Officeid",
                table: "TicketMinors",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_Employees_Requesterid",
                table: "TicketMinors",
                column: "Requesterid",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CategoryLists_CategoryListid",
                table: "Tickets",
                column: "CategoryListid",
                principalTable: "CategoryLists",
                principalColumn: "CategoryListid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeID",
                table: "Tickets",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ITGroups_ITGroupid",
                table: "Tickets",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Offices_Officeid",
                table: "Tickets",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_Users_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_Categories_Categoryid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_ITGroups_ITGroupid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLists_Severities_Severityid",
                table: "CategoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEmployees_Employees_EmployeeID",
                table: "GroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                table: "GroupEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                table: "ITGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_CategoryLists_CategoryListid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_Offices_Officeid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketMinors_Employees_Requesterid",
                table: "TicketMinors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CategoryLists_CategoryListid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ITGroups_ITGroupid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Offices_Officeid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_Users_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "TypeEmployees");

            migrationBuilder.DropTable(
                name: "EmployeeEmployeeTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_Categories_Categoryid",
                table: "CategoryLists",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "Categoryid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_ITGroups_ITGroupid",
                table: "CategoryLists",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLists_Severities_Severityid",
                table: "CategoryLists",
                column: "Severityid",
                principalTable: "Severities",
                principalColumn: "Severityid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeid",
                table: "Employees",
                column: "EmployeeTypeid",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_Officeid",
                table: "Employees",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEmployees_Employees_EmployeeID",
                table: "GroupEmployees",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                table: "GroupEmployees",
                column: "ITGroupMemberid",
                principalTable: "ITGroupMembers",
                principalColumn: "ITGroupMemberid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                table: "ITGroupMembers",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_CategoryLists_CategoryListid",
                table: "TicketMinors",
                column: "CategoryListid",
                principalTable: "CategoryLists",
                principalColumn: "CategoryListid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_Offices_Officeid",
                table: "TicketMinors",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketMinors_Employees_Requesterid",
                table: "TicketMinors",
                column: "Requesterid",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CategoryLists_CategoryListid",
                table: "Tickets",
                column: "CategoryListid",
                principalTable: "CategoryLists",
                principalColumn: "CategoryListid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeID",
                table: "Tickets",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ITGroups_ITGroupid",
                table: "Tickets",
                column: "ITGroupid",
                principalTable: "ITGroups",
                principalColumn: "ITGroupid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Offices_Officeid",
                table: "Tickets",
                column: "Officeid",
                principalTable: "Offices",
                principalColumn: "Officeid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_Users_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
