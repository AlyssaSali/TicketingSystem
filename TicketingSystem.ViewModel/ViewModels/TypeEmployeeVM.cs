using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
   public class TypeEmployeeVM
    {
        public string TypeEmployeeid { get; set; }

        public string EmployeeEmployeeTypeid { get; set; }

        public EmployeeEmployeeTypeVM EmployeeEmployeeType { get; set; }

        public string EmployeeID { get; set; }
        public EmployeeVM Employee { get; set; }

        public string EmployeeFullName { get; set; }
    }
}
