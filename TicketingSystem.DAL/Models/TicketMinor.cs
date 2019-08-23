using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class TicketMinor
    {
        [Key]
        public Guid TicketMinorid { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string WorkDone { get; set; }

        //[Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfRequest { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime TimeOfRequest { get; set; }

        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }

        [ForeignKey("Employee")]
        public Guid Requesterid { get; set; }
        public Guid WorkByid { get; set; }
        public Employee Employee { get; set; }
        
        [ForeignKey("CategoryList")]
        public Guid CategoryListid { get; set; }
        public CategoryList CategoryList { get; set; }
    }
}
