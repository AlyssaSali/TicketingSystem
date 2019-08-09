using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    class ToModel
    {
        public Employee Employee(EmployeeVM employeeVM)
        {
            return new Employee
            {
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                EmailAddress = employeeVM.EmailAddress,
                Office = employeeVM.Office
            };
        }
    }
}
