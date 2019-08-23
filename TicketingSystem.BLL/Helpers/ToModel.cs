using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToModel
    {
        public Office Office(OfficeVM officeVM)
        {
            return new Office
            {
                Officeid = officeVM.Officeid,
                OfficeCode = officeVM.OfficeCode,
                OfficeDesc = officeVM.OfficeDesc,
            };
        }

        public Category Category(CategoryVM categoryVM)
        {
            return new Category
            {
                Categoryid = categoryVM.Categoryid,
                CategoryName = categoryVM.CategoryName,
            };
        }

        public Severity Severity(SeverityVM severityVM)
        {
            return new Severity
            {
                Severityid = severityVM.Severityid,
                SeverityName = severityVM.SeverityName,
                SeverityCode = severityVM.SeverityCode,
                SeverityDesc = severityVM.SeverityDesc
            };
        }
        public Employee Employee(EmployeeVM employeeVM)
        { 
            return new Employee
            { 
                EmployeeID = employeeVM.EmployeeID,                
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                FormOfCommu = employeeVM.FormOfCommu,
                ContactInfo = employeeVM.ContactInfo,
                EmployeeTypeid = employeeVM.EmployeeTypeid,
                Officeid = Guid.Parse(employeeVM.Officeid)
            };
        }

        public Ticket Ticket(TicketVM ticketVM)
        {
            return new Ticket
            {
                Ticketid = ticketVM.Ticketid,
                CategoryListid = ticketVM.CategoryListid,
                ITGroupid = ticketVM.ITGroupid,
                EmployeeID = ticketVM.EmployeeID,
                Officeid = ticketVM.Officeid,
                DateOfRequest = ticketVM.DateOfRequest,
                FormOfCommu = ticketVM.FormOfCommu,
                ContactInfo = ticketVM.ContactInfo,
                RequestTitle = ticketVM.RequestTitle,
                RequestDesc = ticketVM.RequestDesc,
                Category = ticketVM.Category,
                Severity = ticketVM.Severity,
                TrackingStatus = ticketVM.TrackingStatus,
                ResponseTime = ticketVM.ResponseTime,
                ResolveTime = ticketVM.ResolveTime,
                IsUrgent = ticketVM.IsUrgent,
                IsOpen = ticketVM.IsOpen
            };
        }
        public ITGroup ITGroup(ITGroupVM itgroupVM)
        {
            return new ITGroup
            {
                ITGroupid = itgroupVM.ITGroupid,
                ITGroupCode = itgroupVM.ITGroupCode,
                ITGroupName = itgroupVM.ITGroupName,
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

        public EmployeeType EmployeeType(EmployeeTypeVM employeetypeVM)
        {
            return new EmployeeType
            {
                EmployeeTypeid = employeetypeVM.EmployeeTypeid,
                EmployeeTypeName = employeetypeVM.EmployeeTypeName
            };
        }
    }
}
