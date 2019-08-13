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
<<<<<<< HEAD
=======

>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
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
=======
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
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
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
<<<<<<< HEAD
                Officeid = Guid.Parse(employeeVM.Officeid)
            };
        }

        public Ticket Ticket(TicketVM ticketVM)
        {
            return new Ticket
            {
                Ticketid = ticketVM.Ticketid,
                DateOfRequest = ticketVM.DateOfRequest,
                FormOfCommu = ticketVM.FormOfCommu,
                ContactInfo = ticketVM.ContactInfo,
                RequestTitle = ticketVM.RequestTitle,
                RequestDesc = ticketVM.RequestDesc,
                TrackingSatus = ticketVM.TrackingSatus,
                ResponseTime = ticketVM.ResponseTime,
                ResolveTime = ticketVM.ResolveTime,
                IsUrgent = ticketVM.IsUrgent,
                IsOpen = ticketVM.IsOpen
=======
                Office = employeeVM.Office
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
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
