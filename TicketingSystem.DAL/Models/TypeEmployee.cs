using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class TypeEmployee
    {
        [Key]
        public Guid TypeEmployeeid { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeFullName { get; set; }
        [ForeignKey("EmployeeEmployeeType")]
        public Guid EmployeeEmployeeTypeid { get; set; }
        public EmployeeEmployeeType EmployeeEmployeeType { get; set; }
    }
}
