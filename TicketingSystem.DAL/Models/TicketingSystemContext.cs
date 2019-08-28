﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class TicketingSystemContext : DbContext
    {
        public TicketingSystemContext(DbContextOptions<TicketingSystemContext> options) : base(options)
        {

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

        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<TicketMinor> TicketMinors { get; set; }
    }
}
