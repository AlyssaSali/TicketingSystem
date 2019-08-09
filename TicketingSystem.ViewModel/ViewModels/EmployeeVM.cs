using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class EmployeeVM
    {
        [Required]
        public long EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }
        [Required]
        public string Office { get; set; }

    }
}
