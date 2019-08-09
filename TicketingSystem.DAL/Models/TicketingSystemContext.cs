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
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
