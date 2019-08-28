using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Office
    {
        [Key]
        public Guid Officeid { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeDesc { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
<<<<<<< HEAD
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
=======
=======
<<<<<<< HEAD

        public virtual ICollection<Ticket> Tickets { get; set; }

=======
<<<<<<< HEAD
        public virtual ICollection<Ticket> Tickets { get; set; }
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }

>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

    }
}
