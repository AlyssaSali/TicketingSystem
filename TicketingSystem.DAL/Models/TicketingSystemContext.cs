using Microsoft.EntityFrameworkCore;
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
<<<<<<< HEAD
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
=======
        public DbSet<Category> Categories { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<CategoryList> CategoryLists { get; set; }
=======

        public DbSet<Office> Offices { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ITGroup> ITGroups { get; set; }
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
    }
}
