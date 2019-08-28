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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
                {
                    b.Property<Guid>("Categoryid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid?>("Severityid");

                    b.HasKey("Categoryid");

                    b.HasIndex("Severityid");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.CategoryList", b =>
                {
                    b.Property<Guid>("CategoryListid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryListName");

<<<<<<< HEAD
                    b.Property<Guid?>("severityid");
=======
                    b.Property<string>("CategoryType");

                    b.Property<Guid>("Categoryid");
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

                    b.Property<Guid>("ITGroupid");

<<<<<<< HEAD
                    b.HasIndex("severityid");
=======
                    b.Property<Guid>("Severityid");

                    b.Property<int>("SlaResolvedTime");
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

                    b.Property<string>("SlaResolvedTimeExt");

                    b.Property<int>("SlaResponseTime");

                    b.Property<string>("SlaResponseTimeExt");

                    b.HasKey("CategoryListid");

                    b.HasIndex("Categoryid");

                    b.HasIndex("ITGroupid");

                    b.HasIndex("Severityid");

                    b.ToTable("CategoryLists");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactInfo");

                    b.Property<string>("EmailAddress");

                    b.Property<Guid>("EmployeeTypeid");

                    b.Property<string>("FirstName");

                    b.Property<string>("FormOfCommu");

                    b.Property<string>("LastName");

                    b.Property<Guid>("Officeid");

                    b.HasKey("EmployeeID");

                    b.HasIndex("EmployeeTypeid");

                    b.HasIndex("Officeid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.EmployeeEmployeeType", b =>
                {
                    b.Property<Guid>("EmployeeEmployeeTypeid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeTypeid");

                    b.HasKey("EmployeeEmployeeTypeid");

                    b.HasIndex("EmployeeTypeid");

                    b.ToTable("EmployeeEmployeeTypes");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.EmployeeType", b =>
                {
                    b.Property<Guid>("EmployeeTypeid")
                        .ValueGeneratedOnAdd();

<<<<<<< HEAD
                    b.Property<string>("EmployeeTypeName");

                    b.HasKey("EmployeeTypeid");
=======
<<<<<<< HEAD
                    b.Property<string>("ContactInfo");

                    b.Property<Guid>("EmployeeTypeid");

                    b.Property<string>("FirstName");

                    b.Property<string>("FormOfCommu");

=======
                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
                    b.Property<string>("LastName");

                    b.Property<Guid>("Officeid");

                    b.HasKey("EmployeeID");

<<<<<<< HEAD
                    b.HasIndex("EmployeeTypeid");

=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
                    b.HasIndex("Officeid");
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

                    b.ToTable("EmployeeTypes");
                });

<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.EmployeeType", b =>
                {
                    b.Property<Guid>("EmployeeTypeid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeTypeName");

                    b.HasKey("EmployeeTypeid");

                    b.ToTable("EmployeeTypes");
=======
            modelBuilder.Entity("TicketingSystem.DAL.Models.GroupEmployee", b =>
                {
                    b.Property<Guid>("GroupEmployeeid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeFullName");

                    b.Property<Guid>("EmployeeID");

                    b.Property<Guid>("ITGroupMemberid");

                    b.HasKey("GroupEmployeeid");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ITGroupMemberid");

                    b.ToTable("GroupEmployees");
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.ITGroup", b =>
                {
                    b.Property<Guid>("ITGroupid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ITGroupCode");

                    b.Property<string>("ITGroupName");

                    b.HasKey("ITGroupid");

                    b.ToTable("ITGroups");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.ITGroupMember", b =>
                {
                    b.Property<Guid>("ITGroupMemberid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ITGroupid");

                    b.HasKey("ITGroupMemberid");

                    b.HasIndex("ITGroupid");

                    b.ToTable("ITGroupMembers");
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
                    b.Property<Guid>("Severityid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SeverityCode");

                    b.Property<string>("SeverityDesc");

                    b.Property<string>("SeverityName");

                    b.HasKey("Severityid");

                    b.ToTable("Severities");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Ticket", b =>
                {
                    b.Property<Guid>("Ticketid")
                        .ValueGeneratedOnAdd();
<<<<<<< HEAD

                    b.Property<string>("Category");

                    b.Property<Guid>("CategoryListid");

                    b.Property<string>("ContactInfo");

                    b.Property<DateTime>("DateOfRequest");

                    b.Property<Guid>("EmployeeID");

                    b.Property<string>("FormOfCommu");

                    b.Property<Guid>("ITGroupid");

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsUrgent");

                    b.Property<Guid>("Officeid");

                    b.Property<string>("RequestDesc");

                    b.Property<string>("RequestTitle");

                    b.Property<DateTime>("ResolveTime");

                    b.Property<DateTime>("ResponseTime");

                    b.Property<string>("Severity");

                    b.Property<string>("TrackingStatus");

                    b.Property<Guid?>("categoryid");

                    b.Property<Guid?>("severityid");

                    b.HasKey("Ticketid");

                    b.HasIndex("CategoryListid");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ITGroupid");

                    b.HasIndex("Officeid");

                    b.HasIndex("categoryid");

                    b.HasIndex("severityid");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Severity")
                        .WithMany("Categories")
                        .HasForeignKey("severityid");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.CategoryList", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Category", "Category")
                        .WithMany("CategoryLists")
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade);
=======

                    b.Property<string>("Category");

<<<<<<< HEAD
                    b.Property<Guid>("CategoryListid");

                    b.Property<Guid?>("Categoryid");
=======
                    b.Property<Guid>("Categoryid");
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

                    b.Property<string>("ContactInfo");

                    b.Property<DateTime>("DateOfRequest");

                    b.Property<Guid>("EmployeeID");

                    b.Property<string>("FormOfCommu");

                    b.Property<Guid>("ITGroupid");

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsUrgent");

                    b.Property<Guid>("Officeid");

                    b.Property<string>("RequestDesc");

                    b.Property<string>("RequestTitle");

                    b.Property<DateTime>("ResolveTime");

                    b.Property<DateTime>("ResponseTime");

                    b.Property<string>("Severity");

                    b.Property<Guid?>("Severityid");

                    b.Property<string>("TrackingStatus");

                    b.HasKey("Ticketid");

                    b.HasIndex("CategoryListid");

                    b.HasIndex("Categoryid");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ITGroupid");

                    b.HasIndex("Officeid");

                    b.HasIndex("Severityid");

                    b.ToTable("Tickets");
                });

<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.TicketMinor", b =>
=======
<<<<<<< HEAD
<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.Employee", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeTypeid")
                        .OnDelete(DeleteBehavior.Cascade);

=======
            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
                {
                    b.Property<Guid>("TicketMinorid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryListid");

                    b.Property<DateTime>("DateOfRequest");

                    b.Property<string>("Description");

                    b.Property<Guid>("Officeid");

                    b.Property<Guid>("Requesterid");

                    b.Property<string>("Status");

                    b.Property<DateTime>("TimeOfRequest");

                    b.Property<Guid>("WorkByid");

                    b.Property<string>("WorkDone");

                    b.HasKey("TicketMinorid");

                    b.HasIndex("CategoryListid");

                    b.HasIndex("Officeid");

                    b.HasIndex("Requesterid");

                    b.ToTable("TicketMinors");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.TypeEmployee", b =>
                {
                    b.Property<Guid>("TypeEmployeeid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeEmployeeTypeid");

                    b.Property<string>("EmployeeFullName");

                    b.Property<Guid>("EmployeeID");

<<<<<<< HEAD
                    b.HasKey("TypeEmployeeid");

                    b.HasIndex("EmployeeEmployeeTypeid");
=======
<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.Employee", b =>
                {
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
                    b.HasOne("TicketingSystem.DAL.Models.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("Officeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.Ticket", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.CategoryList", "CategoryList")
                        .WithMany()
                        .HasForeignKey("CategoryListid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany("Tickets")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.ITGroup", "ITGroup")
                        .WithMany("Tickets")
                        .HasForeignKey("ITGroupid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Office", "Office")
                        .WithMany("Tickets")
                        .HasForeignKey("Officeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Category")
                        .WithMany("Tickets")
                        .HasForeignKey("categoryid");

                    b.HasOne("TicketingSystem.DAL.Models.Severity")
                        .WithMany("Tickets")
                        .HasForeignKey("severityid");
=======
            modelBuilder.Entity("TicketingSystem.DAL.Models.GroupEmployee", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany("GroupEmployees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

                    b.HasIndex("EmployeeID");

                    b.ToTable("TypeEmployees");
                });

<<<<<<< HEAD
            modelBuilder.Entity("TicketingSystem.DAL.Models.User", b =>
=======
            modelBuilder.Entity("TicketingSystem.DAL.Models.ITGroupMember", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.ITGroup", "ITGroup")
                        .WithMany()
                        .HasForeignKey("ITGroupid")
                        .OnDelete(DeleteBehavior.Cascade);
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
            modelBuilder.Entity("TicketingSystem.DAL.Models.TicketMinor", b =>
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Answer");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Question");

                    b.Property<Guid>("Userid");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Category", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Severity")
                        .WithMany("Categories")
                        .HasForeignKey("Severityid");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.CategoryList", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Category", "Category")
                        .WithMany("CategoryLists")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.ITGroup", "ITGroup")
                        .WithMany("CategoryLists")
                        .HasForeignKey("ITGroupid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Severity", "Severity")
                        .WithMany("CategoryLists")
                        .HasForeignKey("Severityid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Employee", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeTypeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("Officeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.EmployeeEmployeeType", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.EmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.GroupEmployee", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany("GroupEmployees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.ITGroupMember", "ITGroupMember")
                        .WithMany("GroupEmployees")
                        .HasForeignKey("ITGroupMemberid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.ITGroupMember", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.ITGroup", "ITGroup")
                        .WithMany("ITGroupMembers")
                        .HasForeignKey("ITGroupid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.Ticket", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.CategoryList", "CategoryList")
                        .WithMany()
                        .HasForeignKey("CategoryListid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Category")
                        .WithMany("Tickets")
                        .HasForeignKey("Categoryid");

                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany("Tickets")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.ITGroup", "ITGroup")
                        .WithMany("Tickets")
                        .HasForeignKey("ITGroupid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Office", "Office")
                        .WithMany("Tickets")
                        .HasForeignKey("Officeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Severity")
                        .WithMany("Tickets")
                        .HasForeignKey("Severityid");
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.TicketMinor", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.CategoryList", "CategoryList")
                        .WithMany("TicketMinors")
                        .HasForeignKey("CategoryListid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Office", "Office")
                        .WithMany("TicketMinors")
                        .HasForeignKey("Officeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany("TicketMinors")
                        .HasForeignKey("Requesterid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketingSystem.DAL.Models.TypeEmployee", b =>
                {
                    b.HasOne("TicketingSystem.DAL.Models.EmployeeEmployeeType", "EmployeeEmployeeType")
                        .WithMany("TypeEmployees")
                        .HasForeignKey("EmployeeEmployeeTypeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketingSystem.DAL.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
