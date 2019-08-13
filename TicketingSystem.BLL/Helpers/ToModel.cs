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
=======

>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
        public Office Office(OfficeVM officeVM)
        {
            return new Office
            {
                Officeid = officeVM.Officeid,
                OfficeCode = officeVM.OfficeCode,
                OfficeDesc = officeVM.OfficeDesc,
            };
        }
<<<<<<< HEAD

        public Category Category(CategoryVM categoryVM)
        {
            return new Category
            {
                categoryid = categoryVM.categoryid,
                CategoryName = categoryVM.CategoryName,
            };
        }

        public Severity Severity(SeverityVM severityVM)
=======
        public Employee Employee(EmployeeVM employeeVM)
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
        {
            return new Severity
            {
<<<<<<< HEAD
                severityid = severityVM.severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
=======
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                EmailAddress = employeeVM.EmailAddress,
                Office = employeeVM.Office
            };
        }
        public ITGroup ITGroup(ITGroupVM itgroupVM)
        {
            return new ITGroup
            {
                ITGroupid = itgroupVM.ITGroupid,
                ITGroupCode = itgroupVM.ITGroupCode,
                ITGroupName = itgroupVM.ITGroupName,
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
            };
        }

        public CategoryList CategoryList(CategoryListVM categorylistVM)
        {
            return new CategoryList
            {
                CategoryListid = categorylistVM.CategoryListid,
                CategoryListName = categorylistVM.CategoryListName,
                SlaResponseTime = categorylistVM.SlaResponseTime,
                SlaResolvedTime = categorylistVM.SlaResolvedTime,
                ItGroup = categorylistVM.ItGroup,
                categoryid = categorylistVM.categoryid,
                severityid = categorylistVM.severityid
            };
        }

    }
}
