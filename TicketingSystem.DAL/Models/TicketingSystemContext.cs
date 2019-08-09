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
<<<<<<< HEAD
        public DbSet<Office> Offices { get; set; }
=======
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234
    }
}
