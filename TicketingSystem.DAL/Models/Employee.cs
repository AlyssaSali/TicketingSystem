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
<<<<<<< HEAD
        public string FormOfCommu { get; set; }
        public string ContactInfo { get; set; }


        [ForeignKey("EmployeeType")]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeType EmployeeType { get; set; }

=======
        public string EmailAddress { get; set; }
        
        
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad

        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
        public virtual ICollection<Ticket> Tickets { get; set; }
=======
        public List<GroupEmployee> GroupEmployees { get; set; }
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    }
}
