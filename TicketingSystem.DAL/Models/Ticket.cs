using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Ticket
    {
        [Key]
        public Guid Ticketid { get; set; }//PK
        public Guid AssistByid { get; set; }// FK - UserAccount
        public Guid Categoryid { get; set; }// FK - Category
        public Guid Severityid { get; set; }// FK - Severity
        public Guid ItGroupid { get; set; }// FK - ITGroup
        public Guid RequestedBy { get; set; }// FK - Employee
        public Guid Officeid { get; set; }// FK - Office
        public DateTime DateOfRequest { get; set; }
        public string FormOfCommu { get; set; }
        public string ContactInfo { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDesc { get; set; }
        public string TrackingSatus { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public TimeSpan ResolveTime { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsOpen { get; set; }


    }
}
