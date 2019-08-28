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
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public string FormOfCommu { get; set; }
        public string ContactInfo { get; set; }


<<<<<<< HEAD
        //[ForeignKey("EmployeeType")]
        //public Guid EmployeeTypeid { get; set; }
        //public EmployeeType EmployeeType { get; set; }

=======
        [ForeignKey("EmployeeType")]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeType EmployeeType { get; set; }

=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public string EmailAddress { get; set; }
        
        
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad

        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }

<<<<<<< HEAD
        public virtual ICollection<Ticket> Tickets { get; set; }

        public List<GroupEmployee> GroupEmployees { get; set; }
        public List<TypeEmployee> TypeEmployees { get; set; }

=======
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual ICollection<Ticket> Tickets { get; set; }
=======
        public List<GroupEmployee> GroupEmployees { get; set; }
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }

    }
}
