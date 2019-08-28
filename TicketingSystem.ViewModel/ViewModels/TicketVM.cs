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
        public Guid EmployeeID { get; set; }// FK - Employee
        public EmployeeVM Employee { get; set; }
        [Required]
        public Guid Officeid { get; set; }// FK - Office
        public OfficeVM Office { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        [Required]
        public string RequestTitle { get; set; }
        [Required]
        public string RequestDesc { get; set; }
        public string TrackingStatus { get; set; }
        public string RequestedBy { get; set; }// FK - UserAccount
        public string IsOpen { get; set; }
    }
}
