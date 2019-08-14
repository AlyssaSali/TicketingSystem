using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Tickets",
                columns: table => new
                {
                    Ticketid = table.Column<Guid>(nullable: false),
                    AssistByid = table.Column<Guid>(nullable: false),
                    Categoryid = table.Column<Guid>(nullable: false),
                    Severityid = table.Column<Guid>(nullable: false),
                    ItGroupid = table.Column<Guid>(nullable: false),
                    RequestedBy = table.Column<Guid>(nullable: false),
                    Officeid = table.Column<Guid>(nullable: false),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    FormOfCommu = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    RequestTitle = table.Column<string>(nullable: true),
                    RequestDesc = table.Column<string>(nullable: true),
                    TrackingSatus = table.Column<string>(nullable: true),
                    ResponseTime = table.Column<TimeSpan>(nullable: false),
                    ResolveTime = table.Column<TimeSpan>(nullable: false),
                    IsUrgent = table.Column<bool>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticketid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Officeid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
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
                    categoryid1 = table.Column<Guid>(nullable: true),
                    severityid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryid);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_categoryid1",
                        column: x => x.categoryid1,
                        principalTable: "Categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_categoryid1",
                table: "Categories",
                column: "categoryid1");

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
                name: "IX_Employees_Officeid",
                table: "Employees",
                column: "Officeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ITGroups");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Severities");
        }
    }
}
