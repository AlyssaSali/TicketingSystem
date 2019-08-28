using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormOfCommu { get; set; }
        public string ContactInfo { get; set; }


        [ForeignKey("EmployeeType")]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeType EmployeeType { get; set; }

        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public List<GroupEmployee> GroupEmployees { get; set; }
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
    }
}
