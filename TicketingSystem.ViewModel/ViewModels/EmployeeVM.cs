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
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public string FormOfCommu { get; set; }
        [Required]
        public string ContactInfo { get; set; }

<<<<<<< HEAD
        //[Required]
        //public Guid EmployeeTypeid { get; set; }
        //public EmployeeTypeVM EmployeeType { get; set; }

        public string EmailAddress { get; set; }
=======
        [Required]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeTypeVM EmployeeType { get; set; }

=======
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        [Required]
        public string Officeid { get; set; }
        public OfficeVM Office { get; set; }

        public virtual List<GroupEmployeeVM> GroupEmployees { get; set; }

        public virtual List<TypeEmployeeVM> TypeEmployees { get; set; }

    }
}
