using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class addedemptype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeid = table.Column<Guid>(nullable: false),
                    EmployeeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeid);
                });

            migrationBuilder.CreateTable(
                name: "ITGroups",
                columns: table => new
                {
                    ITGroupid = table.Column<Guid>(nullable: false),
                    ITGroupCode = table.Column<string>(nullable: true),
                    ITGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITGroups", x => x.ITGroupid);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Officeid = table.Column<Guid>(nullable: false),
                    OfficeCode = table.Column<string>(nullable: true),
                    OfficeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Officeid);
                });

            migrationBuilder.CreateTable(
                name: "Severities",
                columns: table => new
                {
                    severityid = table.Column<Guid>(nullable: false),
                    SeverityCode = table.Column<string>(nullable: true),
                    SeverityName = table.Column<string>(nullable: true),
                    SeverityDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severities", x => x.severityid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FormOfCommu = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    EmployeeTypeid = table.Column<Guid>(nullable: false),
                    Officeid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeid",
                        column: x => x.EmployeeTypeid,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_Officeid",
                        column: x => x.Officeid,
                        principalTable: "Offices",
                        principalColumn: "Officeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    severityid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryid);
                    table.ForeignKey(
                        name: "FK_Categories_Severities_severityid",
                        column: x => x.severityid,
                        principalTable: "Severities",
                        principalColumn: "severityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLists",
                columns: table => new
                {
                    CategoryListid = table.Column<Guid>(nullable: false),
                    CategoryListName = table.Column<string>(nullable: true),
                    SlaResponseTime = table.Column<int>(nullable: false),
                    SlaResolvedTime = table.Column<int>(nullable: false),
                    ItGroup = table.Column<string>(nullable: true),
                    categoryid = table.Column<Guid>(nullable: false),
                    severityid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLists", x => x.CategoryListid);
                    table.ForeignKey(
                        name: "FK_CategoryLists_Categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryLists_Severities_severityid",
                        column: x => x.severityid,
                        principalTable: "Severities",
                        principalColumn: "severityid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticketid = table.Column<Guid>(nullable: false),
                    ITGroupid = table.Column<Guid>(nullable: false),
                    EmployeeID = table.Column<Guid>(nullable: false),
                    Officeid = table.Column<Guid>(nullable: false),
                    CategoryListid = table.Column<Guid>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    FormOfCommu = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    RequestTitle = table.Column<string>(nullable: true),
                    RequestDesc = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Severity = table.Column<string>(nullable: true),
                    TrackingStatus = table.Column<string>(nullable: true),
                    ResponseTime = table.Column<DateTime>(nullable: false),
                    ResolveTime = table.Column<DateTime>(nullable: false),
                    IsUrgent = table.Column<bool>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    categoryid = table.Column<Guid>(nullable: true),
                    severityid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticketid);
                    table.ForeignKey(
                        name: "FK_Tickets_CategoryLists_CategoryListid",
                        column: x => x.CategoryListid,
                        principalTable: "CategoryLists",
                        principalColumn: "CategoryListid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_ITGroups_ITGroupid",
                        column: x => x.ITGroupid,
                        principalTable: "ITGroups",
                        principalColumn: "ITGroupid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Offices_Officeid",
                        column: x => x.Officeid,
                        principalTable: "Offices",
                        principalColumn: "Officeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Severities_severityid",
                        column: x => x.severityid,
                        principalTable: "Severities",
                        principalColumn: "severityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_severityid",
                table: "Categories",
                column: "severityid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLists_categoryid",
                table: "CategoryLists",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLists_severityid",
                table: "CategoryLists",
                column: "severityid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeid",
                table: "Employees",
                column: "EmployeeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Officeid",
                table: "Employees",
                column: "Officeid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryListid",
                table: "Tickets",
                column: "CategoryListid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeID",
                table: "Tickets",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ITGroupid",
                table: "Tickets",
                column: "ITGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Officeid",
                table: "Tickets",
                column: "Officeid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_categoryid",
                table: "Tickets",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_severityid",
                table: "Tickets",
                column: "severityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CategoryLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ITGroups");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Severities");
        }
    }
}
