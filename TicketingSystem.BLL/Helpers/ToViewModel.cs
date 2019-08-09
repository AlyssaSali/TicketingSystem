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
       public SeverityVM Severity(Severity severity)
       {
            return new SeverityVM
            {
                ID = severity.ID,
                SeverityCode = severity.SeverityCode,
                SeverityDesc = severity.SeverityDesc
            };
       }
=======
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
>>>>>>> d03904ae63c76b400a8493dbaf62e20d91bc2e2f
    }
}
