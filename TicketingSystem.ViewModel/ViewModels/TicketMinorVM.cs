using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class TicketMinorVM
    {
        public Guid TicketMinorid { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string WorkDone { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfRequest { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime TimeOfRequest { get; set; }

        [Required]
        public string Officeid { get; set; }
        public OfficeVM Office { get; set; }

        public string Requesterid { get; set; }
        public string WorkByid { get; set; }
        public EmployeeVM Employee { get; set; }

        [Required]
        public string CategoryListid { get; set; }
        public CategoryListVM CategoryList { get; set; }
    }
}
