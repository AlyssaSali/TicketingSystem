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
        public int SeverityCode { get; set; }
        public string SeverityName { get; set; }
        public string SeverityDesc { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<CategoryList> CategoryLists { get; set; }

    }
}
