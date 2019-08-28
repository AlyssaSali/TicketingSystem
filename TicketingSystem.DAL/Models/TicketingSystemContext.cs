﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class TicketingSystemContext : IdentityDbContext
    {
        public TicketingSystemContext(DbContextOptions<TicketingSystemContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users"); });
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });

            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogin"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });




        }
        public DbSet<Office> Offices { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<CategoryList> CategoryLists { get; set; }

        public DbSet<ITGroup> ITGroups { get; set; }

        public DbSet<ITGroupMember> ITGroupMembers { get; set; }
        public DbSet<GroupEmployee> GroupEmployees { get; set; }
        public DbSet<EmployeeEmployeeType> EmployeeEmployeeTypes { get; set; }

        public DbSet<TypeEmployee> TypeEmployees { get; set; }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        public DbSet<TicketMinor> TicketMinors { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
