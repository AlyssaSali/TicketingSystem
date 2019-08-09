using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToViewModel
    {
<<<<<<< HEAD
        public OfficeVM Office(Office office)
        {
            return new OfficeVM
            {
                Officeid = office.Officeid,
                OfficeCode = office.OfficeCode,
                OfficeDesc = office.OfficeDesc,

=======
        public EmployeeVM Employee(Employee employee)
        {
            return new EmployeeVM
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
                Office = employee.Office
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234
            };
        }
    }
}
