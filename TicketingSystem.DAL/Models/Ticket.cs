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
        //public Guid AssistByid { get; set; }// FK - UserAccount
        [ForeignKey("ITGroup")]
        public Guid ITGroupid { get; set; }
        public ITGroup ITGroup { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Office")]
        public Guid Officeid { get; set; }
        public Office Office { get; set; }
        [ForeignKey("CategoryList")]
        public Guid CategoryListid { get; set; }
        public CategoryList CategoryList { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string FormOfCommu { get; set; }
        public string ContactInfo { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDesc { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string TrackingStatus { get; set; }
        public DateTime ResponseTime { get; set; }
        public DateTime ResolveTime { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsOpen { get; set; }


    }
}
