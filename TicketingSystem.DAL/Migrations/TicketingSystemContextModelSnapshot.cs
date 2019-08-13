﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.DAL.Models;

namespace TicketingSystem.DAL.Migrations
{
    [DbContext(typeof(TicketingSystemContext))]
    partial class TicketingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
                {
                    b.Property<Guid>("categoryid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<Guid?>("categoryid1");

                    b.Property<Guid?>("severityid");

                    b.HasKey("categoryid");

                    b.HasIndex("categoryid1");

                    b.HasIndex("severityid");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.CategoryList", b =>
                {
                    b.Property<Guid>("CategoryListid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryListName");

                    b.Property<string>("ItGroup");

                    b.Property<int>("SlaResolvedTime");

                    b.Property<int>("SlaResponseTime");

                    b.Property<Guid>("categoryid");

                    b.Property<Guid>("severityid");

                    b.HasKey("CategoryListid");

                    b.HasIndex("categoryid");

                    b.HasIndex("severityid");

                    b.ToTable("CategoryLists");
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

            modelBuilder.Entity("TicketingSystem.DAL.Models.Severity", b =>
                {
                    b.Property<Guid>("severityid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SeverityCode");

                    b.Property<string>("SeverityDesc");

                    b.Property<string>("SeverityName");

                    b.HasKey("severityid");

                    b.ToTable("Severities");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Category")
                        .WithMany("Categories")
                        .HasForeignKey("categoryid1");

                    b.HasOne("TicketingSystem.DAL.Models.Severity")
                        .WithMany("Categories")
                        .HasForeignKey("severityid");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.CategoryList", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Severity", "Severity")
                        .WithMany()
                        .HasForeignKey("severityid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
