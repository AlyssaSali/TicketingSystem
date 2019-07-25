using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Department
    {
        [Key]
        public long ID { get; set; }
        public string DepCode { get; set; }
        public string DepDesc { get; set; }
      
    }
}
