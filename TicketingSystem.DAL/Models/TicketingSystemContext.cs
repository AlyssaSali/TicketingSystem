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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<CategoryList> CategoryLists { get; set; }
    }
}
