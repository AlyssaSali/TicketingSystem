using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToModel
    {
<<<<<<< HEAD
        public Severity Severity(SeverityVM severityVM)
        {
            return new Severity
            {
                ID = severityVM.ID,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
=======
<<<<<<< HEAD
        public Office Office(OfficeVM officeVM)
        {
            return new Office
            {
                Officeid = officeVM.Officeid,
                OfficeCode = officeVM.OfficeCode,
                OfficeDesc = officeVM.OfficeDesc,

=======
        public Employee Employee(EmployeeVM employeeVM)
        {
            return new Employee
            {
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                EmailAddress = employeeVM.EmailAddress,
                Office = employeeVM.Office
>>>>>>> 46c58e86a322ff5f84c1b927d6a1c93aafe67234
>>>>>>> d03904ae63c76b400a8493dbaf62e20d91bc2e2f
            };
        }
    }
}
