using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
<<<<<<< HEAD:TicketingSystem.DAL/Migrations/20190808103123_initial.cs
                name: "Offices",
                columns: table => new
                {
                    Officeid = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficeCode = table.Column<string>(nullable: true),
                    OfficeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Officeid);
=======
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234:TicketingSystem.DAL/Migrations/20190808030438_initial.cs
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<< HEAD:TicketingSystem.DAL/Migrations/20190808103123_initial.cs
                name: "Offices");
=======
                name: "Employees");
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234:TicketingSystem.DAL/Migrations/20190808030438_initial.cs
        }
    }
}
