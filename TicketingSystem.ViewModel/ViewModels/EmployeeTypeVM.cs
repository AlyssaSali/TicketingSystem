using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class EmployeeTypeVM
    {
        [Required]
        public Guid EmployeeTypeid { get; set; }
        [Required]
        public string EmployeeTypeName { get; set; }
    }
}
