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

<<<<<<< HEAD
        //public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeEmployeeType> EmployeeEmployeeTypes { get; set; }
=======
        public virtual ICollection<Employee> Employees { get; set; }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    }
}
