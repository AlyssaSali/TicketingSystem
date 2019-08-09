using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Office
    {
        [Key]
        public long Officeid { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeDesc { get; set; }

    }
}
