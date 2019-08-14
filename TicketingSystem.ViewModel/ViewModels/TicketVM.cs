using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class TicketVM
    {
        [Required]
        public Guid Ticketid { get; set; }//PK
        [Required]
        public Guid AssistByid { get; set; }// FK - UserAccount
        [Required]
        public Guid Categoryid { get; set; }// FK - Category
        [Required]
        public Guid Severityid { get; set; }// FK - Severity
        [Required]
        public Guid ItGroupid { get; set; }// FK - ITGroup
        [Required]
        public Guid RequestedBy { get; set; }// FK - Employee
        [Required]
        public Guid Officeid { get; set; }// FK - Office
        [Required]
        public DateTime DateOfRequest { get; set; }
        [Required]
        public string FormOfCommu { get; set; }
        [Required]
        public string ContactInfo { get; set; }
        [Required]
        public string RequestTitle { get; set; }
        [Required]
        public string RequestDesc { get; set; }
        [Required]
        public string TrackingSatus { get; set; }
        [Required]
        public TimeSpan ResponseTime { get; set; }
        [Required]
        public TimeSpan ResolveTime { get; set; }
        [Required]
        public bool IsUrgent { get; set; }
        [Required]
        public bool IsOpen { get; set; }
    }
}
