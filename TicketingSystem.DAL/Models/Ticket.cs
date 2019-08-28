using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Ticket
    {
        [Key]
        public Guid Ticketid { get; set; }//PK        
        [ForeignKey("Employee")]
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDesc { get; set; }
        public string TrackingStatus { get; set; }
        public string RequestedBy { get; set; }// FK - UserAccount
        public string IsOpen { get; set; }


    }
}
