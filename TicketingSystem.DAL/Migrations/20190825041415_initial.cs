using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class initial : Migration
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Userid = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITGroupMembers",
                columns: table => new
                {
                    ITGroupMemberid = table.Column<Guid>(nullable: false),
                    ITGroupid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITGroupMembers", x => x.ITGroupMemberid);
                    table.ForeignKey(
                        name: "FK_ITGroupMembers_ITGroups_ITGroupid",
                        column: x => x.ITGroupid,
                        principalTable: "ITGroups",
                        principalColumn: "ITGroupid",
                        onDelete: ReferentialAction.Restrict);
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
                    EmailAddress = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_Officeid",
                        column: x => x.Officeid,
                        principalTable: "Offices",
                        principalColumn: "Officeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Categoryid = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Severityid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categoryid);
                    table.ForeignKey(
                        name: "FK_Categories_Severities_Severityid",
                        column: x => x.Severityid,
                        principalTable: "Severities",
                        principalColumn: "Severityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupEmployees_ITGroupMembers_ITGroupMemberid",
                        column: x => x.ITGroupMemberid,
                        principalTable: "ITGroupMembers",
                        principalColumn: "ITGroupMemberid",
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
                    Categoryid = table.Column<Guid>(nullable: true),
                    Severityid = table.Column<Guid>(nullable: true)
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
                        name: "FK_Tickets_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "Categoryid",
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
                        name: "FK_Tickets_Severities_Severityid",
                        column: x => x.Severityid,
                        principalTable: "Severities",
                        principalColumn: "Severityid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Severityid",
                table: "Categories",
                column: "Severityid");

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
                name: "IX_Employees_EmployeeTypeid",
                table: "Employees",
                column: "EmployeeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Officeid",
                table: "Employees",
                column: "Officeid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmployees_EmployeeID",
                table: "GroupEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEmployees_ITGroupMemberid",
                table: "GroupEmployees",
                column: "ITGroupMemberid");

            migrationBuilder.CreateIndex(
                name: "IX_ITGroupMembers_ITGroupid",
                table: "ITGroupMembers",
                column: "ITGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryListid",
                table: "Tickets",
                column: "CategoryListid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Categoryid",
                table: "Tickets",
                column: "Categoryid");

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
                name: "IX_Tickets_Severityid",
                table: "Tickets",
                column: "Severityid");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEmployees");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "TicketMinors");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ITGroupMembers");

            migrationBuilder.DropTable(
                name: "CategoryLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ITGroups");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Severities");
        }
    }
}
