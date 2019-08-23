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
        //[Required]
        //public Guid AssistByid { get; set; }// FK - UserAccount

        [Required]
        public Guid CategoryListid { get; set; }// FK - Category
        public CategoryListVM CategoryList { get; set; }        
        [Required]
        public Guid ITGroupid { get; set; }// FK - ITGroup
        public ITGroupVM ITGroup { get; set; }
        [Required]
        public Guid EmployeeID { get; set; }// FK - Employee
        public EmployeeVM Employee { get; set; }
        [Required]
        public Guid Officeid { get; set; }// FK - Office
        public OfficeVM Office { get; set; }
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
        public string Severity { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string TrackingStatus { get; set; }
        //[Required]
        public DateTime ResponseTime { get; set; }
        //[Required]
        public DateTime ResolveTime { get; set; }
        [Required]
        public bool IsUrgent { get; set; }
        [Required]
        public bool IsOpen { get; set; }
    }
}
