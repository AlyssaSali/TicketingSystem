using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class EmployeeType
    {
        [Key]
        public Guid EmployeeTypeid { get; set; }
        public string EmployeeTypeName { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeEmployeeType> EmployeeEmployeeTypes { get; set; }
    }
}
