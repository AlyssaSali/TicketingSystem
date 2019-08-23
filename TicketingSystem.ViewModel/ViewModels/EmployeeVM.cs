using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class EmployeeVM
    {
        [Required]
        public Guid EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
<<<<<<< HEAD
        public string FormOfCommu { get; set; }
        [Required]
        public string ContactInfo { get; set; }

        [Required]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeTypeVM EmployeeType { get; set; }

=======
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
        [Required]
        public string Officeid { get; set; }
        public OfficeVM Office { get; set; }

        public virtual List<GroupEmployeeVM> GroupEmployees { get; set; }

    }
}
