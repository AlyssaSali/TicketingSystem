﻿using System;
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
<<<<<<< HEAD

        public virtual ICollection<Ticket> Tickets { get; set; }

=======
<<<<<<< HEAD
        public virtual ICollection<Ticket> Tickets { get; set; }
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15


    }
}
