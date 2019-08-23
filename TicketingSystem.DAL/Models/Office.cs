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
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }

    }
}
