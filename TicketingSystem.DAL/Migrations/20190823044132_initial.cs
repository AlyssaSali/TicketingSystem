using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Categoryid = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categoryid);
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
                    Severityid = table.Column<Guid>(nullable: false),
                    SeverityCode = table.Column<int>(nullable: false),
                    SeverityName = table.Column<string>(nullable: true),
                    SeverityDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severities", x => x.Severityid);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLists",
                columns: table => new
                {
                    CategoryListid = table.Column<Guid>(nullable: false),
                    CategoryListName = table.Column<string>(nullable: true),
                    CategoryType = table.Column<string>(nullable: true),
                    SlaResponseTime = table.Column<int>(nullable: false),
                    SlaResponseTimeExt = table.Column<string>(nullable: true),
                    SlaResolvedTime = table.Column<int>(nullable: false),
                    SlaResolvedTimeExt = table.Column<string>(nullable: true),
                    Categoryid = table.Column<Guid>(nullable: false),
                    Severityid = table.Column<Guid>(nullable: false),
                    ITGroupid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLists", x => x.CategoryListid);
                    table.ForeignKey(
                        name: "FK_CategoryLists_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryLists_ITGroups_ITGroupid",
                        column: x => x.ITGroupid,
                        principalTable: "ITGroups",
                        principalColumn: "ITGroupid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryLists_Severities_Severityid",
                        column: x => x.Severityid,
                        principalTable: "Severities",
                        principalColumn: "Severityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketMinors",
                columns: table => new
                {
                    TicketMinorid = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    WorkDone = table.Column<string>(nullable: true),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    TimeOfRequest = table.Column<DateTime>(nullable: false),
                    Officeid = table.Column<Guid>(nullable: false),
                    Requesterid = table.Column<Guid>(nullable: false),
                    WorkByid = table.Column<Guid>(nullable: false),
                    CategoryListid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMinors", x => x.TicketMinorid);
                    table.ForeignKey(
                        name: "FK_TicketMinors_CategoryLists_CategoryListid",
                        column: x => x.CategoryListid,
                        principalTable: "CategoryLists",
                        principalColumn: "CategoryListid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketMinors_Offices_Officeid",
                        column: x => x.Officeid,
                        principalTable: "Offices",
                        principalColumn: "Officeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketMinors_Employees_Requesterid",
                        column: x => x.Requesterid,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLists_Categoryid",
                table: "CategoryLists",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLists_ITGroupid",
                table: "CategoryLists",
                column: "ITGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLists_Severityid",
                table: "CategoryLists",
                column: "Severityid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Officeid",
                table: "Employees",
                column: "Officeid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMinors_CategoryListid",
                table: "TicketMinors",
                column: "CategoryListid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMinors_Officeid",
                table: "TicketMinors",
                column: "Officeid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMinors_Requesterid",
                table: "TicketMinors",
                column: "Requesterid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketMinors");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CategoryLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ITGroups");

            migrationBuilder.DropTable(
                name: "Severities");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
