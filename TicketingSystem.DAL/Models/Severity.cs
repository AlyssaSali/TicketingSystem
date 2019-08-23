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
        public string SeverityCode { get; set; }
        public string SeverityName { get; set; }
        public string SeverityDesc { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
=======
        public int SeverityCode { get; set; }
        public string SeverityName { get; set; }
        public string SeverityDesc { get; set; }

        public virtual ICollection<CategoryList> CategoryLists { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

    }
}
