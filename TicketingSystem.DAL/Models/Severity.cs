using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Severity
    {
        [Key]
        public Guid ID { get; set; }
        public string SeverityCode { get; set; }
        public string SeverityDesc { get; set; }
    }
}
