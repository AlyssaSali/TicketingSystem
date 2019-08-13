﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.DAL.Models;

namespace TicketingSystem.DAL.Migrations
{
    [DbContext(typeof(TicketingSystemContext))]
<<<<<<< HEAD:TicketingSystem.DAL/Migrations/20190809054040_init.Designer.cs
    [Migration("20190809054040_init")]
    partial class init
=======
    [Migration("20190810060539_initial")]
    partial class initial
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86:TicketingSystem.DAL/Migrations/20190810060539_initial.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketingSystem.DAL.Models.Employee", b =>
<<<<<<< HEAD:TicketingSystem.DAL/Migrations/20190809054040_init.Designer.cs
                {
                    b.Property<Guid>("EmployeeID")
=======
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Office");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.ITGroup", b =>
                {
                    b.Property<Guid>("ITGroupid")
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86:TicketingSystem.DAL/Migrations/20190810060539_initial.Designer.cs
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ITGroupCode");

                    b.Property<string>("ITGroupName");

                    b.HasKey("ITGroupid");

<<<<<<< HEAD:TicketingSystem.DAL/Migrations/20190809054040_init.Designer.cs
                    b.Property<string>("Office");

                    b.HasKey("EmployeeID");
=======
                    b.ToTable("ITGroups");
                });
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86:TicketingSystem.DAL/Migrations/20190810060539_initial.Designer.cs

            modelBuilder.Entity("TicketingSystem.DAL.Models.Office", b =>
                {
                    b.Property<Guid>("Officeid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OfficeCode");

                    b.Property<string>("OfficeDesc");

                    b.HasKey("Officeid");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Office", b =>
                {
                    b.Property<Guid>("Officeid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OfficeCode");

                    b.Property<string>("OfficeDesc");

                    b.HasKey("Officeid");

                    b.ToTable("Offices");
                });
#pragma warning restore 612, 618
        }
    }
}