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
        public string EmailAddress { get; set; }
        
        

        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }

<<<<<<< HEAD
        public List<GroupEmployee> GroupEmployees { get; set; }
=======
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    }
}
