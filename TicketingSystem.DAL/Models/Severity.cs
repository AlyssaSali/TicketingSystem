using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Severity
    {
        [Key]
        public Guid Severityid { get; set; }
<<<<<<< HEAD
        public int SeverityCode { get; set; }
=======
<<<<<<< HEAD
        public int SeverityCode { get; set; }
=======
<<<<<<< HEAD

=======
<<<<<<< HEAD
        public string SeverityCode { get; set; }
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
        public string SeverityName { get; set; }
        public string SeverityDesc { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
<<<<<<< HEAD
=======
        public virtual ICollection<Ticket> Tickets { get; set; }
<<<<<<< HEAD
=======
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public int SeverityCode { get; set; }
        public string SeverityName { get; set; }
        public string SeverityDesc { get; set; }
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
<<<<<<< HEAD
=======

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

    }
}
